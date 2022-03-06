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



        [HttpPost("postRole")]
        public Role Post([FromBody] Role Action)
        {
            return _mediator.Send(new PostId<Role>(Action)).Result;
        }


        [HttpGet("getById")]
        public Role GetbyId(Guid id)
        {
            var data = _mediator.Send(new GetGenericQueryById<Role>(g => g.RoleId == id)).Result;
            return _mapper.Map<Role>(data);
        }
        [HttpDelete("deleteRole")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<Role>(id)).Result;
        }
        [HttpPut("updateRole")]
        public string Put([FromBody] Role Role)
        {
            return _mediator.Send(new PutGeneric<Role>(Role)).Result;
        }


    }
}
//}