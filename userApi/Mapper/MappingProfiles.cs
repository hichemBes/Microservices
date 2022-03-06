using AutoMapper;
using Domain.Models;
using userApi.Dto;
using System.Linq;
using Data.Repositry;

namespace userApi.Mapper
{
    public class MappingProfiles : Profile
    {
        FillialeRepository F = new FillialeRepository();

        public MappingProfiles()
        {
          CreateMap<RoleOfUser, RoleofuserDto>()
         .ForMember(des => des.rolename, i => i.MapFrom(src => src.role.Name)).ForMember(des => des.label, i => i.MapFrom(src => src.role.label)) 
         .ForMember(des => des.username, i => i.MapFrom(src => src.user.name))
         .ForMember(des => des.cin, i => i.MapFrom(src => src.user.Cin))
         .ForMember(des => des.fillialeName, i => i.MapFrom(src =>
F.GetSubsidiaryById(src.user.fk_Filliale).FillialeName)).ReverseMap();

            CreateMap<User, UserDto>().ForMember(des => des.Namefilliale, i => i.MapFrom(src =>
F.GetSubsidiaryById(src.fk_Filliale).FillialeName)).ForMember(des=>des.code,i=>i.MapFrom(src => F.GetSubsidiaryById(src.fk_Filliale).FillialeCode))
  .ReverseMap();

        }
    }
}
