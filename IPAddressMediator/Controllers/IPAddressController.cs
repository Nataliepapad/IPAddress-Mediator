using IPAddressMediator.Commands;
using IPAddressMediator.Entities;
using IPAddressMediator.Models;
using IPAddressMediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IPMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IPController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetIPAddress")]
        public async Task<ActionResult<IPAddressModel>> GetIPAddress(string ip)
        {
            IPAddressModel model = await _mediator.Send(new GetIPAddress(ip));
            return model == null ? NotFound() : Ok(model); ;
        }

        [HttpPost("AddIPAddress")]
        public async Task<ActionResult<IPAddress>> AddIPAddress(IPAddress ipAddress)
        {
            IPAddress model = await _mediator.Send(new AddIPAddress(ipAddress));
            return Ok(model);
        }
    }
}