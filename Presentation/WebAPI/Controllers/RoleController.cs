using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.RoleDto;
using Application.Features.Commands.Role;
using Application.Features.Commands.Role.AssigningRole;
using Application.Features.Queries.AppRole;
using Domain.Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<AppRoleQueryResponse>> GetAllRole()
        {
            var query = new AppRoleQueryRequest();
            var req = await _mediator.Send(query);
            return Ok(req);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommandRequest createRoleCommandRequest)
        {
            var req = await _mediator.Send(createRoleCommandRequest);
            return Ok(req);
        }
        
        [HttpPost]
        public async Task<IActionResult> AssigningRole(AssigningRoleCommandRequest assigningRoleCommandRequest)
        {
            var req = await _mediator.Send(assigningRoleCommandRequest);
            return Ok(req);
        }
    }
}
