using IPAddressMediator.IP2CIntegration;
using MediatR;
using System.Net;

namespace IPAddressMediator.Queries
{
    public class GetIPAddress : IRequest<IP2CResponse>
    {
        public IPAddress IP { get; }

        public GetIPAddress(IPAddress ip)
        {
            IP = ip;
        }
    }
}
