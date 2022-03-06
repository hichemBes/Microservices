using AutoMapper;
using Domain.Comands;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using userApi.Dto;

namespace userApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleOfUserController
    {


        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoleOfUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpPost("postRole")]
        public RoleOfUser  Post([FromBody] RoleOfUser  Action)
        {
            return _mediator.Send(new PostId<RoleOfUser>(Action)).Result;
        }
        [HttpGet(" Getuserbyrole")]
        public IEnumerable<RoleofuserDto> Getuserbyrole(Guid roleid)
        {
            var data = _mediator.Send(new GetAllGenericQuery<RoleOfUser>(includes:
               i => i.Include(s => s.role).ThenInclude(it => it.roleOfUsers).ThenInclude(it => it.user), condition: x => x.FK_Role == roleid)).Result.Select(data => _mapper.Map<RoleofuserDto>(data));

            return data;

        }
          [HttpGet(" Getalluserbyrole")]
        public IEnumerable<RoleofuserDto> Getalluserbyrole()
        {
            var data = _mediator.Send(new GetAllGenericQuery<RoleOfUser>(includes:
               i => i.Include(s => s.role).ThenInclude(it => it.roleOfUsers).ThenInclude(it => it.user))).Result.Select(data => _mapper.Map<RoleofuserDto>(data));

            return data;

        }
        [HttpGet(" GetrolebyUser")]
        public IEnumerable<RoleofuserDto> Getallrolebyuser(Guid userid)
        {
            var data = _mediator.Send(new GetAllGenericQuery<RoleOfUser>(includes:
              i => i.Include(s => s.user).ThenInclude(it => it.roleOfUsers).ThenInclude(it => it.role), condition: x => x.Fk_User == userid)).Result.Select(data => _mapper.Map<RoleofuserDto>(data));

            return data;
        }

    }
}