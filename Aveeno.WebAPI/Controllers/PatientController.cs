
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using PatientBlDto = BusinessLibrary.Patient;
using AutoMapper;
using System.Web.Http.Cors;
using Framework;



namespace Aveeno.WebAPI
{
    //[System.Web.Http.RoutePrefix("patient")]
    [EnableCors(origins: "http://localhost:30793", headers: "*", methods: "*")]

    public class PatientController : ApiController
    {
        private BusinessLibrary.IPatientManager patientManager;
        private ILogger logger;
      
        public PatientController(BusinessLibrary.IPatientManager manager, ILogger log)
        {
            
            patientManager = manager;
            logger = log;
        }
        // GET: api/Default
        public IEnumerable<Patient> GetAll()
        {
            logger.Info("info :Information");
           // logger.Error("error ", new Exception("custom error"));
            return Mapper.Map<IEnumerable<PatientBlDto>, IEnumerable<Patient>>(patientManager.GetAllPatients());            
        }

        /// <summary>
        /// Get Patient by patient id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public IHttpActionResult Get(int id)
        {
      
            var result = Mapper.Map<PatientBlDto, Patient>(patientManager.GetPatient(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/Default
        public IHttpActionResult Post(Patient patient)
        {
            try
            {

                var result = patientManager.AddPatient(Mapper.Map<Patient, PatientBlDto>(patient));
                if(result.Status==Framework.Status.Failed)
                    return InternalServerError(new Exception(string.Join(",",result.Messages)));
                return Ok<int>(result.returnObject.PatientId);
            }
            catch(Exception ex)
            {
              return InternalServerError(new Exception("couldn't save the data"));
            }          
        }

        // PUT: api/Default/5
        public void Put(int id, Patient patient)
        {            
              patientManager.UpdatePatient(Mapper.Map<Patient, PatientBlDto>(patient));                          
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
            patientManager.DeletePatient(id);   
        }
       

       
    }
}
