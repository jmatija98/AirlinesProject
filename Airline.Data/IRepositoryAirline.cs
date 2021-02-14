using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Airline.Data
{
    public interface IRepositoryAirline : IRepository<Airlines>
    {
        void Change(Airlines airlineNew);

    }


}
