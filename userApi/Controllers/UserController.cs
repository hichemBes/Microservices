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
    public class UserController
    {


        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            var data = _mediator.Send(new GetAllGenericQuery<User>(includes:
            i => i.Include(s => s.Role))).Result.Select(data => _mapper.Map<UserDto>(data));

            return data;

        }
        [HttpPost("postUser")]
        public UserDto Post([FromBody] UserDto Action)
        {
            return _mediator.Send(new PostId<UserDto>(Action)).Result;
        }
        [HttpDelete("deleteUser")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<User>(id)).Result;
        }
        [HttpGet("getById")]
        public UserDto GetbyId(Guid id)
        {
          var   data =_mediator.Send(new GetGenericQueryById<User>(g => g.userId== id)).Result;
            return _mapper.Map<UserDto>(data);
        }
        [HttpPut("putUser")]
        public string Put([FromBody] User User)
        {
            return _mediator.Send(new PutGeneric<User>(User)).Result;

        }
    }
}
