using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class PilotGroupViewModel
    {
        public int Num { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Miles { get; set; }
        [Required]

        public int AirlinesID { get; set; }
    }
}
