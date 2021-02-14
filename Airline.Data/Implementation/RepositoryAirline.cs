using Airline.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data.Implementation
{
    public class RepositoryAirline : IRepositoryAirline
    {
        private AirlineContext context;
        public RepositoryAirline(AirlineContext context)
        {
            this.context = context;
        }
        
        public void Add(Airlines s)
        {
            context.Add(s);
        }

        public void Change(Airlines airlineNew)
        {
            var airline = context.Airlines.First(a => a.AirlinesID == airlineNew.AirlinesID);
            airline.CountryId = airlineNew.CountryId;
            airline.Name = airlineNew.Name;
            airline.NumberOfPlanes = airlineNew.NumberOfPlanes;
            airline.YearFounded = airlineNew.YearFounded;
            
        }

        public void Delete(int airline_id)
        {
            Airlines a = context.Airlines.Find(airline_id);
            context.Remove(a);
        }

        public Airlines FindById(int id)
        {
            Airlines a = context.Airlines.Find(id);
            return a;
        }

        public List<Airlines> GetAll()
        {
            List<Airlines> a = context.Airlines.ToList();
            return a;
        }
        
    }
}
