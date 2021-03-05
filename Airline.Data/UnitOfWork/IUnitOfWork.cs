using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public IRepositoryAirline Airlines { get; set; }
        public IRepositoryCountry Country { get; set; }
        public IRepositoryPilot Pilot { get; set; }
        public IRepositoryFlight Flight { get; set; }

        void Commit();
    }
}
