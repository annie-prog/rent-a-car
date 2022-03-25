using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Services
{
    public class AuthenticationService
    {
        public User LoggedUser { get; private set; }
        public void AuthenticateUser(string username, string password)
        {
            RentACarDbContext context = new RentACarDbContext();
            this.LoggedUser = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
