using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Domain
{
    public class Country
    {  

        public int CountryID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{CountryID}: {Name}";
        }
    }
}
