using IPAddressMediator.IP2CIntegration;
using IPAddressMediator.Models;
using IPAddressMediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IPMediator.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetIPAddressModel")]
        public async Task<ActionResult<IP2CResponse>> GetIPAddressModel(string ip)
        {
            var model = await _mediator.Send(new GetIPAddress(ip));
            return Ok(model); ;
        }

        [HttpGet("GetStatistics")]
        public ActionResult<List<StatisticsModel>> GetStatistics([FromQuery] string[] twoLetterCodes)
        {
            var result = _mediator.Send(new GetStatistics(twoLetterCodes));

            return Ok(result);
        }
    }
}