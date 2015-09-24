using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aveeno.WebAPI
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }
        public string Sex { get; set; }     
        public int Age { get; set; }
    }
}