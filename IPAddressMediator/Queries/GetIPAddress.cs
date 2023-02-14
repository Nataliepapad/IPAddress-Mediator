using IPAddressMediator.IP2CIntegration;
using MediatR;

namespace IPAddressMediator.Queries
{
    public class GetIPAddress : IRequest<IP2CResponse>
    {
        public string IP { get; }

        public GetIPAddress(string ip)
        {
            IP = ip;
        }
    }
}
