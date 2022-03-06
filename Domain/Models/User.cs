using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using userApi.ForiegnDtos;

namespace Domain.Models
{
    public  class User
    {
        public Guid userId { get; set; }
        public string name { get; set; }
    
        public string  Cin { get; set; }
      
        public Guid  fk_Filliale { get; set; }

        public ICollection<RoleOfUser> roleOfUsers{ get; set; }



    }
}
