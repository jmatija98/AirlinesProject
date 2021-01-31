using Airline.Data.UnitOfWork;
using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airline.ConsoleA
{
    class Program
    {
        static void Main(string[] args)
        {
            using IUnitOfWork uow = new AirlineUnitOfWork(new AirlineContext());
            /*
            //country methods test
             
            Country c1 = new Country { Name = "Croatia" };
            Country c2 = new Country { Name = "Serbia" };
            uow.Country.Add(c1);
            uow.Country.Add(c2);
            Country c=uow.Country.FindById(3);
            Console.WriteLine(c);

            List<Country> listC = uow.Country.GetAll();
            listC.ForEach(c => Console.WriteLine(c));
            */

            /*
             //airline method test
            Country c4 = uow.Country.FindById(4);
            Country c3 = uow.Country.FindById(3);
            Airlines a1 = new Airlines { Name = "AirSerbia", YearFounded = 1950, NumberOfPlanes = 3, Country = c4 };
            Airlines a2 = new Airlines { Name = "JAT", YearFounded = 1900, NumberOfPlanes = 33, Country = c4 };
            Airlines a3 = new Airlines { Name = "FlyCroatia", YearFounded = 1960, NumberOfPlanes = 3, Country = c3 };
            Airlines a=uow.Airline.FindById(3);
            List<Airlines> aList = uow.Airline.GetAll();
            aList.ForEach(c => Console.WriteLine(c));
            */

            
            //pilot method test
            
            
       
            uow.Commit();
        }
    }
}
