using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data
{
    public interface IRepositoryAdmins: IRepository<Admin>
    {
        Admin getByUsernamePassword(string username, string password);
    }
}
