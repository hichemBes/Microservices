using AutoMapper;
using Domain.Comands;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using userApi.Dto;
using userApi.ForiegnDtos;

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
               i => i.Include(s => s.roleOfUsers).ThenInclude(it => it.role))).Result.Select(data => _mapper.Map<UserDto>(data));

            return data;

        }

        [HttpGet("getfiliale")]
        public FillialeDto GetSubsidiaryById(Guid fillialeId)
        {
            HttpClient _httpClient = new HttpClient();
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:44349/api/Filliale/" + fillialeId).Result;
            response.EnsureSuccessStatusCode();
            System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<FillialeDto>(responseBody);
        }


        [HttpGet("getallfiliale")]
        public IEnumerable<FillialeDto> GetSubsidiary()
        {
            HttpClient _httpClient = new HttpClient();
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:44349/api/Filliale/GetAll").Result;
            response.EnsureSuccessStatusCode();
            System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<FillialeDto>>(responseBody);
        }



        [HttpPost("postUser")]
        public User Post([FromBody] User user)
        {
            return _mediator.Send(new PostId<User>(user)).Result;
        }
        [HttpDelete("deleteUser")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<User>(id)).Result;
        }
   
//[HttpGet("getById")]
//public UserDto GetbyId(Guid id)
//{
//  var   data =_mediator.Send(new GetGenericQueryById<User> (includes: i=>i.Include(b=>b.Role),condition:
//      x=>x.Role.fk_user==id)

//    //return _mapper.Map<UserDto>(data);
//}

[HttpPut("putUser")]
public string Put([FromBody] User User)
{
    return _mediator.Send(new PutGeneric<User>(User)).Result;

}
    }
}

