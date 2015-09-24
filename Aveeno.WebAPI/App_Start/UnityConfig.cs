using BusinessLibrary;
using DataAccessLibrary;
using Framework;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Aveeno.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILogger, NLogLogger>();
            container.RegisterType<IPatientManager, PatientManager>();
            container.RegisterType<IPatientRepository, PatientRepository>();            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}