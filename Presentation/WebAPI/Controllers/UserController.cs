using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.House;
using Application.Features.Queries.Invoice;
using Application.Features.Queries.Invoice.GetByIdInvoice;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<GetHouseQueryResponse>> GetAllHouse()
        {
            var query = new GetHouseQueryRequest();
            var req = await _mediator.Send(query);
            return Ok(req);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetInvoiceById([FromRoute] GetByIdInvoiceQueryRequest getByIdInvoiceQueryRequest)
        {
            var req = await _mediator.Send(getByIdInvoiceQueryRequest);
            return Ok(req);
        }
    }
}
