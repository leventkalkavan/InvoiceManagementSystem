using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.AppUser.CreateUser;
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
    [Route("api/[controller]")]
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
            var res = await _mediator.Send(createUserCommandRequest);
            return Ok(res);
        }
    }
}
