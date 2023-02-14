using IPAddressMediator.Models;
using MediatR;

namespace IPAddressMediator.Queries
{
    public class GetIPAddress : IRequest<IPAddressModel>
    {
        public string IP { get; }

        public GetIPAddress(string ip)
        {
            IP = ip;
        }
    }
}
