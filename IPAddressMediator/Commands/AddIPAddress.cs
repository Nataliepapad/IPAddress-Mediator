using Azure.Core;
using IPAddressMediator.Data;
using IPAddressMediator.Entities;
using MediatR;

namespace IPAddressMediator.Commands
{
    public class AddIPAddress : IRequest<IPAddress>
    {
        public readonly IPAddress _ipAddress;

        public AddIPAddress(IPAddress ipAddress)
        {
            _ipAddress = new IPAddress
            {
                IP = ipAddress.IP,
                CountryId = ipAddress.CountryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Country = ipAddress.Country,
            };
        }
    }
}
