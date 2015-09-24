using Framework;
using System;
using System.Collections.Generic;
namespace BusinessLibrary
{
    public interface IPatientManager
    {
        Framework.GenericResponse<Patient> AddPatient(Patient patient);
        void DeletePatient(int id);
        System.Collections.Generic.IEnumerable<Patient> GetAllPatients();
        Patient GetPatient(int id);
        void UpdatePatient(Patient patient);
        IEnumerable<Statistics> GetStatistics();
        IEnumerable<Log> GetAllLogs();
    }
}
