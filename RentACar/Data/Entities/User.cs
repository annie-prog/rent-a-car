using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser<string>
    {
        public enum RoleEnum 
        { 
            User, 
            Manager 
        }

        public override string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public override string PhoneNumber { get; set; }

        public override string Email { get; set; }

        public RoleEnum Role { get; set; }
    }
}
