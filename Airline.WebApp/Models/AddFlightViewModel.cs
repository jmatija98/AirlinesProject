using Airline.Domain.Validations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class AddFlightViewModel
    {
        [FlightDate(ErrorMessage = "Date must be after or equal to current date")]
        public DateTime Date { set; get; }
        [Range(1, int.MaxValue, ErrorMessage = "Input incorrect")]
        public int DurationInMinutes { set; get; }
        [Required(ErrorMessage = "Please enter departure!")]
        public string StartDestination { set; get; }
        [Required(ErrorMessage = "Please enter arrival!")]
        public string EndDestination { set; get; }
        [Range(1, int.MaxValue, ErrorMessage ="Input incorrect")]
        [Required(ErrorMessage = "Please enter price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please choose pilot")]
        public int PilotID { set; get; }
        [Required(ErrorMessage = "Please choose pilot")]
        public List<SelectListItem> Pilots { set; get; }

    }
}
