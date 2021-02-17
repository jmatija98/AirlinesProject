using Airline.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
            context.Entry(airlineNew).State = EntityState.Modified;

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
