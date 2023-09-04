using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.AppUser.CreateUser;
using Application.Features.Commands.AppUser.DeleteUser;
using Application.Features.Commands.AppUser.UpdateUser;
using Application.Features.Commands.House;
using Application.Features.Commands.House.DeleteHouse;
using Application.Features.Commands.House.UpdateHouse;
using Application.Features.Commands.Invoice.CreateInvoice;
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
        
        //UserController

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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]DeleteUserCommandRequest deleteUserCommandRequest)
        {
            var req = await _mediator.Send(deleteUserCommandRequest);
            return Ok(req);
        }
        
        //HouseController

        [HttpPost]
        public async Task<IActionResult> CreateHouse(CreateHouseCommandRequest createHouseCommandRequest)
        {
            var req = await _mediator.Send(createHouseCommandRequest);
            return Ok(req);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHouse(UpdateHouseCommandRequest updateHouseCommandRequest)
        {
            var req = await _mediator.Send(updateHouseCommandRequest);
            return Ok(req);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteHouse([FromRoute] DeleteHouseCommandRequest deleteHouseCommandRequest)
        {
            var req = await _mediator.Send(deleteHouseCommandRequest);
            return Ok(req);
        }
        
        //InvoiceController

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceCommandRequest createInvoiceCommandRequest)
        {
            var req = await _mediator.Send(createInvoiceCommandRequest);
            return Ok(req);
        }
    }
}
