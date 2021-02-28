using System;
using Airline.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Airline.Domain.Validations;

namespace Airline.WebApp.Models
{
    public class AddAirlinesViewModel
    {
        [Required(ErrorMessage ="Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter year")]
        [AirlineYear(ErrorMessage ="Invalid input. Try again")]
        public int YearFounded { set; get; }
        [Required(ErrorMessage = "Please enter number")]
        public int NumberOfPlanes { set; get; }
        [Required(ErrorMessage = "Please choose country")]
        public int CountryID { set; get; }
        public List<SelectListItem> Countries { set; get; }
        
    }
}
