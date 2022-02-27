using AutoMapper;
using Domain.Models;
using userApi.Dto;
using System.Linq;

namespace userApi.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().
                ForMember(des => des.RoleName, i => i.MapFrom(src => src.Role.Name)).ReverseMap();
            CreateMap<Role, RoleDto>().
               ForMember(des => des.nbre_users, i => i.MapFrom(src => src.User.Count())).ReverseMap();
        
        }
    }
}
