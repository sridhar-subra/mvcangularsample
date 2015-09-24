using AutoMapper;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using LogBlDto = BusinessLibrary.Log;

namespace Aveeno.WebAPI.Controllers
{
   
    [EnableCors(origins: "http://localhost:30793", headers: "*", methods: "*")]
    public class LogController : ApiController
    {
        private BusinessLibrary.IPatientManager patientManager;      
        public LogController(BusinessLibrary.IPatientManager manager)
        {
            patientManager = manager;
        }
        public IEnumerable<Log> GetAllLogs()
        {
            return Mapper.Map<IEnumerable<LogBlDto>, IEnumerable<Log>>(patientManager.GetAllLogs());             
        }
    }
}