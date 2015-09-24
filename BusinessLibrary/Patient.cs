using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Framework;

namespace BusinessLibrary
{
    public class Patient : DomainModelBase
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}
