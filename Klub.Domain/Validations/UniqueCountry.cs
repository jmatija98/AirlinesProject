using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;
using System.Linq;


namespace Airline.Domain.Validations
{
    class UniqueCountry: ValidationAttribute
    {
        private AirlineContext context = new AirlineContext();
        
        public override bool IsValid(object value)
        {
            var name = (String)value;
            
            return false;
        }
    }
}
