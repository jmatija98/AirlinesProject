using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.Domain;

namespace Airline.WebApp.Models
{
    public class FlightsWithAirlineWithPilot
    {
        public List<Pilot> Pilots { get; set; }
        public List<Airlines> Airlines { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
