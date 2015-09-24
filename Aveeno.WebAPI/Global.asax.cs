using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Caching;
using System.Web.Mvc;



namespace Aveeno.WebAPI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);          
            UnityConfig.RegisterComponents();            
            AutoMapperBootstrap.Initialize();
            AreaRegistration.RegisterAllAreas();
        }    
    }
}