using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public abstract class DomainModelBase
    {
        protected DomainModelBase()
        {
            BrokenRules = new Collection<ValidationResult>();
        }

        public ICollection<ValidationResult> BrokenRules { get; set; }

        public string[] GetErrorMessages()
        {
            return (from rules in BrokenRules select rules.ErrorMessage).ToArray();
        }
    }
}
