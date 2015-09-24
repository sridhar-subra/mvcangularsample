using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IPatientRepository
    {
        Patient Insert(Patient entity);
        Patient Find(object id);
        void Update(Patient entity);
        void Delete(object id);
        IEnumerable<Patient> GetAll();
        IEnumerable<Log> GetAllLogs();

    }
}
