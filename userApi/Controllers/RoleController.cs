using AutoMapper;
using Domain.Comands;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
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
    public class RoleController
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;



        public RoleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpGet]
        public IEnumerable<RoleDto> Get()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Role>(includes:
               i => i.Include(s => s.User))).Result.Select(data => _mapper.Map<RoleDto>(data));

            return data;

        }
        [HttpPost("postRole")]
        public Role Post([FromBody] Role Action)
        {
            return _mediator.Send(new PostId<Role>(Action)).Result;
        }
        [HttpDelete("deleteRole")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<Role>(id)).Result;
        }
    }
}