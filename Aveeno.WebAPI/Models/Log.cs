namespace Aveeno.WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Log
    {
        public int Id { get; set; }

        public DateTime EventDateTime { get; set; }

  
        public string EventLevel { get; set; }

       
        public string UserName { get; set; }

     
        public string MachineName { get; set; }

   
        public string EventMessage { get; set; }

    
        public string ErrorSource { get; set; }


        public string ErrorClass { get; set; }

        public string ErrorMethod { get; set; }

        public string ErrorMessage { get; set; }

        public string InnerErrorMessage { get; set; }
    }
}
