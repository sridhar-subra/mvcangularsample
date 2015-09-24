using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Aveeno.WebAPI.Controllers
{
   
    [EnableCors(origins: "http://localhost:30793", headers: "*", methods: "*")]
    public class StatisticsController : ApiController
    {
        private BusinessLibrary.IPatientManager patientManager;      
        public StatisticsController(BusinessLibrary.IPatientManager manager)
        {
            patientManager = manager;
        }
        public IEnumerable<Statistics> GetStatistics()
        {
            return patientManager.GetStatistics();
        }
    }
}