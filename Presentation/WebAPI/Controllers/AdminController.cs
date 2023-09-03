using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.AppUser.CreateUser;
using Application.Features.Commands.AppUser.DeleteUser;
using Application.Features.Commands.AppUser.UpdateUser;
using Application.Features.Commands.House;
using Application.Features.Queries.AppUser.GetUsers;
using Application.Repositories.House;
using Domain.Entities;
using Domain.Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        

        public AdminController(IMediator mediator, IHouseWriterRepository houseWriterRepository)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetUserQueryResponse>> GetAllUsers()
        {
            var query = new GetUserQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            var req = await _mediator.Send(createUserCommandRequest);
            return Ok(req);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest updateUserCommandRequest)
        {
            var req = await _mediator.Send(updateUserCommandRequest);
            return Ok(req);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery]DeleteUserCommandRequest deleteUserCommandRequest)
        {
            var req = await _mediator.Send(deleteUserCommandRequest);
            return Ok(req);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouse(CreateHouseCommandRequest createHouseCommandRequest)
        {
            var req = await _mediator.Send(createHouseCommandRequest);
            return Ok(req);
        }
    }
}
