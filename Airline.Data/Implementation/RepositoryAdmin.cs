using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airline.Data.Implementation
{
    public class RepositoryAdmin : IRepositoryAdmins
    {
        private readonly AdminContext context;
        public RepositoryAdmin(AdminContext context) {
            this.context = context;
        }
        public void Add(Admin s)
        {
            this.context.Admins.Add(s);
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Admin FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Admin getByUsernamePassword(string username, string password)
        {
            return context.Admins.Single(a => a.Username == username && a.Password == password);
        }
    }
}
