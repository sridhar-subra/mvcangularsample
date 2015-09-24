using Elmah.Contrib.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aveeno.WebAPI.App_Start
{
    public class CustomError : ElmahExceptionLogger
    {
        
        public CustomError()
        {
            var x = this;
        }
    }
}