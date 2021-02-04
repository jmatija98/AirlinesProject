using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data.AdminUnitOfWork
{
    public interface IAdminUnitOfWork: IDisposable
    {
        public IRepositoryAdmins Admins { set; get; }
        void Commit();
    }
}
