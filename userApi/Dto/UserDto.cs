using System;

namespace userApi.Dto
{
    public class UserDto
    {
        public Guid userId { get; set; }
        public string name { get; set; }
        public string Cin { get; set; }
        public string Namefilliale { get; set; }
        public Guid fk_Filliale { get; set; }
        public string code { get; set; }
        public string rolename { get; set; }
        public string label { get; set; }

    }
}
