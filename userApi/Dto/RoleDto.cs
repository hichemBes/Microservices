using Domain.Models;
using System;
using System.Collections.Generic;

namespace userApi.Dto
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string label { get; set; }
        public int? nbre_users { get; set; }

    }
}
