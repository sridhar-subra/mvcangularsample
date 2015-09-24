using Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class PatientRepository : IPatientRepository
    {
        private PatientContext _db =null;
        private IDbSet<Patient> _dbSet;
        private IDbSet<Log> _dbSetlog;
        public PatientRepository()
        {
             _db = new PatientContext();            
             _dbSet = _db.Set<Patient>();
             _dbSetlog = _db.Set<Log>();
        }
        public Patient Find(object id)
        {
            return _dbSet.Find(id);
        }

        public Patient Insert(Patient entity)
        {
            var res = _dbSet.Add(entity);           
            _db.SaveChanges();
            return res;
        }

        public void Update(Patient entity)
        {
            var result = _dbSet.Find(entity.id);
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.SexOfThePatient = entity.SexOfThePatient;
            result.Age = entity.Age;
            _db.SaveChanges();            
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return _dbSetlog.Take(10).OrderByDescending(x => x.Id).ToList();
        }
    }
}
