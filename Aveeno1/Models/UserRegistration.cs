using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aveeno1.Models
{
    public class UserRegistration
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string Error { get; set; }
    }
}