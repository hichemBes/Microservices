using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class Role
    {

        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string label { get; set; }
        public ICollection<RoleOfUser> roleOfUsers { get; set; }
    }
}
