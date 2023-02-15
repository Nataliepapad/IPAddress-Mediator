using IPAddressMediator.IP2CIntegration;
using IPAddressMediator.Models;
using IPAddressMediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IPMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetIPAddressModel")]
        public async Task<ActionResult<IP2CResponse>> GetIPAddressModel([FromQuery] string ip)
        {
            IPAddress address;
            if (IPAddress.TryParse(ip.Trim(), out address))
            {
                var model = await _mediator.Send(new GetIPAddress(address));
                return Ok(model);
            }
            else
            {
                return BadRequest("");
            }
        }

        [HttpGet("GetStatistics")]
        public ActionResult<List<StatisticsModel>> GetStatistics([FromQuery] string[] twoLetterCodes)
        {
            var result = _mediator.Send(new GetStatistics(twoLetterCodes));
            return Ok(result);
        }
    }
}