using System;

namespace Airline.Domain
{
    public class Airlines
    {
        public int AirlinesID { get; set; }
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public int NumberOfPlanes { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public override string ToString()
        {
            return $"{AirlinesID}: {Name}: {YearFounded}: {Country.Name}";
        }
    }
}
