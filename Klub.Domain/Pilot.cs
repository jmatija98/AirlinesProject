using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Domain
{
    public class Pilot
    {
        public int PilotID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Miles { get; set; }
        public int AirlinesId { get; set; }
        public Airlines Airlines { get; set; }
        public override string ToString()
        {
            return $"{PilotID}: {FirstName}: {LastName}";
        }
    }
}
