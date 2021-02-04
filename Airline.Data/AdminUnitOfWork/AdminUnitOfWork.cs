using Airline.Data.Implementation;
using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Data.AdminUnitOfWork
{
    public class AdminUnitOfWork : IAdminUnitOfWork
    {
        private readonly AdminContext context;
        public AdminUnitOfWork(AdminContext context)
        {
            this.context = context;
            Admins = new RepositoryAdmin(context);
        }
        public IRepositoryAdmins Admins { set; get; }

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
