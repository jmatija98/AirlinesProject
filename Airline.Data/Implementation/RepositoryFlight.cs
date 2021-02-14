using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airline.Data.Implementation
{
    class RepositoryFlight : IRepositoryFlight
    {
        private AirlineContext context;
        public RepositoryFlight(AirlineContext context)
        {
            this.context = context;
        }
        public void Add(Flight f)
        {
            context.Flights.Add(f);
        }

        public void Change(Flight flightNew)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Flight f = context.Flights.Find(id);
            context.Flights.Remove(f);
        }

        public Flight FindById(int id)
        {
            Flight f = context.Flights.Find(id);
            return f;
        }

        public List<Flight> GetAll()
        {
            List<Flight> flights = context.Flights.ToList();
            return flights;
        }
    }
}
