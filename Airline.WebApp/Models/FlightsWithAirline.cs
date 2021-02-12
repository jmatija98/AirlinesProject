using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class FlightsWithAirline
    {
        public List<Airlines> Airlines { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
