using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public IRepositoryAirline Airline { get; set; }
        public IRepositoryCountry Country { get; set; }
        public IRepositoryPilot Pilot { get; set; }

        void Commit();
    }
}
