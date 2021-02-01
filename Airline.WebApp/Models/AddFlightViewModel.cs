using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class AddFlightViewModel
    {
        public DateTime Date { set; get; }
        public int DurationInMinutes { set; get; }
        public string StartDestination { set; get; }
        public string EndDestination { set; get; }
        public int PilotID { set; get; }
        public List<SelectListItem> Pilots { set; get; }

    }
}
