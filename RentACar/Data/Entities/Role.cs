using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public Role(string name) : this()
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
