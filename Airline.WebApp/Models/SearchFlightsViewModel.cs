using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class SearchFlightsViewModel
    { 
        public int startID { get; set; }
        public List<SelectListItem> startDestinations { set; get; }
        public int endID { get; set; }
        public List<SelectListItem> endDestinations { set; get; }
    }
}
