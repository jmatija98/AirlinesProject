using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data
{
    public interface IRepository<T>
    {
        void Add(T s);
        List<T> GetAll();
        T FindById(int id);
        void Delete(int id);       
    }
}
