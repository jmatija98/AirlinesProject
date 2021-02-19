using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Airline.Data
{
    public interface IRepositoryCountry: IRepository<Country>
    {
        void addWithParameters(string Name);
        void change(Country countryNew);
        
    }

   
}
