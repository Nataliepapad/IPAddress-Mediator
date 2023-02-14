using IPAddressMediator.IP2CIntegration;
using IPAddressMediator.Services;
using MediatR;

namespace IPAddressMediator.Queries
{
    public class GetIPAddressHandler : IRequestHandler<GetIPAddress, IP2CResponse>
    {
        private readonly IIPAddressService _ipAddressService;

        public GetIPAddressHandler(IIPAddressService ipAddressService)
        {
            _ipAddressService = ipAddressService;
        }

        public async Task<IP2CResponse> Handle(GetIPAddress request, CancellationToken ct)
        {
            // We try to retrieve the IPAddressModel from the Database
            var response = await _ipAddressService.GetIPAddressByIp(request.IP); ;

            return response;
        }
    }
}

