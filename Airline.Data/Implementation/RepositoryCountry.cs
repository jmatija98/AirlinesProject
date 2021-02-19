using Airline.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Airline.Data.Implementation
{
    public class RepositoryCountry : IRepositoryCountry
    {
        private AirlineContext context;
        public RepositoryCountry(AirlineContext context)
        {
            this.context = context;
        }
        public void Add(Country c)
        {
            context.Add(c);
        }

        public void addWithParameters(string NewName)
        {
            Country c = new Country { Name = NewName };
            context.Add(c);
        }

        public void change(Country c)
        {
            context.Entry(c).State = EntityState.Modified;

        }

        public void Delete(int conutry_id)
        {
            Country c = context.Countries.Single(c => c.CountryID == conutry_id);
            context.Remove(c);
        }

        public Country FindById(int id)
        {
            Country c = context.Countries.Single(c => c.CountryID == id);
            return c;
        }

        public List<Country> GetAll()
        {
            List<Country> c = context.Countries.ToList();
            return c;
        }
    }
}
