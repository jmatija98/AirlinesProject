using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Domain
{
    public class Flight
    {
        public int FlightID { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }

    }
}
