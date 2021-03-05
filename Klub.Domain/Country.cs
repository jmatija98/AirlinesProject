using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Airline.Domain
{
    public class Country
    {  
        [Required]
        public int CountryID { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{CountryID}: {Name}";
        }
    }
}
