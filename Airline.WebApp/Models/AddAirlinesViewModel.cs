using System;
using Airline.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.WebApp.Models
{
    public class AddAirlinesViewModel
    {
        public string Name { get; set; }
        public int YearFounded { set; get; }
        public int NumberOfPlanes { set; get; }
        public int CountryID { set; get; }
        public List<SelectListItem> Countries { set; get; }
        
    }
}
