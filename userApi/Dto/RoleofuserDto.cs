using Domain.Models;
using System;

namespace userApi.Dto
{
    public class RoleofuserDto
    {

        public Guid roleofuserId { get; set; }
        public string label { get; set; }
        public Guid FK_Role { get; set; }
        public Guid Fk_User { get; set; }
        public string rolename { get; set; }
        public string username { get; set; }
        public string cin { get; set; }
        public string fillialeName { get; set; }
    }
}
