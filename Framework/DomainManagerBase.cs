using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class DomainManagerBase
    {
        /// <summary>
        /// Validates the properties of an object if it is decorated with data annotation and stores the result in Broken Rules properties
        /// </summary>
        /// <param name="object">Object to be validated (Doesn't support nested object) </param>
        /// <returns>Passed or Failed validation</returns>
        public bool TryValidate(DomainModelBase @object)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            @object.BrokenRules = new List<ValidationResult>();
            return Validator.TryValidateObject(
                @object, context, @object.BrokenRules,
                validateAllProperties: true
            );
        }
    }
}
