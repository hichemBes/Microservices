using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class User
    {
        public Guid userId { get; set; }
        public string name { get; set; }
        public double Cin { get; set; }
        public Guid  fk_RoleId { get; set; }
        public Role Role { get; set; }


    }
}
