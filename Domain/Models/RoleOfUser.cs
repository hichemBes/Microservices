using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
public class RoleOfUser
    {
       public Guid roleofuserId { get; set; }   
        public Guid Fk_User { get; set; }
        public User user { get; set; }
        public Guid FK_Role { get; set; }
        public Role role { get; set; }

    }
}
