using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Airline.Domain.Validations
{
    public class AirlineYear: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var num = (Int32)value;
            if (num >=1919)
            {
                return true;
            }
            return false;
        }
    }
}
