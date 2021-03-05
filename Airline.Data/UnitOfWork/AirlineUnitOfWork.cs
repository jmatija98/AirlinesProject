using System;
using System.Collections.Generic;
using System.Text;
using Airline.Data.Implementation;
using Airline.Domain;

namespace Airline.Data.UnitOfWork
{
    public class AirlineUnitOfWork : IUnitOfWork
    {
        private AirlineContext context;

        public AirlineUnitOfWork(AirlineContext context)
        {
            this.context = context;
            Airlines = new RepositoryAirline(context);
            Country = new RepositoryCountry(context);
            Pilot = new RepositoryPilot(context);
            Flight = new RepositoryFlight(context);

        }
        public IRepositoryAirline Airlines { get; set; }
        public IRepositoryCountry Country { get; set; }
        public IRepositoryPilot Pilot { get; set; }
        public IRepositoryFlight Flight { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
