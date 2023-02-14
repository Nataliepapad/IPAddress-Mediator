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

        //[HttpPost("addIPAddress")]
        //public async Task<ActionResult<IPAddress>> AddIPAddressToDb(IPAddress IPAddressModel)
        //{
        //    IPAddress model = await _mediator.Send(new AddIPAddress(IPAddressModel));
        //    return Ok(model);
        //}
    }
}