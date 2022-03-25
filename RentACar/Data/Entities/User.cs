using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        public enum RoleEnum 
        { 
            User, 
            Manager 
        }


        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PersonalNumber { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public RoleEnum Role { get; set; }
    }
}
