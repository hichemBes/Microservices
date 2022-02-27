using System;

namespace userApi.Dto
{
    public class UserDto
    {
        public Guid userId { get; set; }
        public string name { get; set; }
        public double Cin { get; set; }
        public Guid fk_RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
