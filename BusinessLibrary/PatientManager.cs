using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PatientDalDto = DataAccessLibrary.Patient;
using LogDalDto = DataAccessLibrary.Log;
using Framework;

namespace BusinessLibrary
{
    public class PatientManager : DomainManagerBase, IPatientManager
    {
        private DataAccessLibrary.IPatientRepository patientRepository;


        public PatientManager(DataAccessLibrary.IPatientRepository repository) 
        {
            patientRepository = repository;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
       
            return Mapper.Map<IEnumerable<PatientDalDto>, IEnumerable<Patient>>
                (patientRepository.GetAll());
           
        }

        public Patient GetPatient(int id)
        {

            return Mapper.Map<PatientDalDto, Patient>(patientRepository.Find(id));
           
        }

     

        // POST: api/Default
        public GenericResponse<Patient> AddPatient(Patient patient)
        {           
               try
               {
                int generatedPatientID = 0;                
                if (patient != null && TryValidate(patient))
                {
                    if (patient.BrokenRules.Count>0)
                    {
                        return new GenericResponse<Patient>
                        {
                            Status = Status.Failed,
                            Messages = patient.GetErrorMessages(),
                            returnObject=patient
                        };
                    }
                    bool generatedPatientIDIsNew = false;                   
                    while (generatedPatientIDIsNew == false)
                    {
                        generatedPatientID = GetRandomPatientID();
                        var res = patientRepository.Find(generatedPatientID);                       
                        if (res == null)
                            generatedPatientIDIsNew = true;
                    }
                    patient.PatientId = generatedPatientID;
                    var patientModel = Mapper.Map<Patient, PatientDalDto>(patient);
                    patientRepository.Insert(patientModel);                                 
                }
                else
                {
                    //simulated : failed becuase of any business rule or validation
                    return new GenericResponse<Patient>
                    {
                        Status = Status.Failed,
                        Messages = patient.GetErrorMessages(),
                        returnObject = patient
                    };
                }
                return new GenericResponse<Patient>
                {
                    Status = Status.Success,
                    returnObject = patient
                };
             }
            catch(Exception ex)
            {
                return new GenericResponse<Patient>
                {
                    Status = Status.Failed,
                    Messages = new string[] { ex.Message},
                    returnObject = patient
                };
            }            
       }

        public void UpdatePatient(Patient patient)
        {
           
            patientRepository.Update(Mapper.Map<Patient, PatientDalDto>(patient));

        }
          


        public void DeletePatient(int id)
        {            
            patientRepository.Delete(id);
        }


        public IEnumerable<Statistics> GetStatistics()
        {
            var result = GetAllPatients();
            List<Statistics> statisticsCln = new List<Statistics>();
            statisticsCln.Add(new Statistics { Label = "Age > 25", Value = result.Where(x => x.Age <= 25).Count() });
            statisticsCln.Add(new Statistics { Label = "Age > 25 && <= 50", Value = result.Where(x => x.Age > 25 && x.Age<=50).Count() });
            statisticsCln.Add(new Statistics { Label = "Age > 50", Value = result.Where(x => x.Age > 50).Count() });
            return statisticsCln;
        }

        public IEnumerable<Log> GetAllLogs()
        {

            return Mapper.Map<IEnumerable<LogDalDto>, IEnumerable<Log>>
                (patientRepository.GetAllLogs());

        }

        /// <summary>
        /// Generates random patient number
        /// </summary>
        /// <returns></returns>
        private int GetRandomPatientID()
        {
            return new Random().Next(10, 999999);
        }
    }
}
