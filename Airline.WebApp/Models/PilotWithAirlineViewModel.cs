using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class PilotWithAirlineViewModel
    {
        public List<Pilot> Pilots { get; set; }
        public List<Airlines> Airlines { get; set; }
    }
}
