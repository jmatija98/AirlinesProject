using Airline.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class AddPilotViewModel
    {
        [Required(ErrorMessage = "Please enter first name!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter miles!")]
        [Range(1, int.MaxValue, ErrorMessage = "Input incorrect")]
        public int Miles { get; set; }
        [Required(ErrorMessage = "Please choose airline")]
        public int AirlinesID { get; set; }
        public List<SelectListItem> Airlines { set; get; }

        public List<Pilot> Pilots { get; set; }
    }
}
