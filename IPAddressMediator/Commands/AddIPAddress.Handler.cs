using IPAddressMediator.Data;
using IPAddressMediator.Entities;
using IPAddressMediator.Models;
using IPAddressMediator.Queries;
using MediatR;

namespace IPAddressMediator.Commands
{
    public class AddIPAddressHandler : IRequestHandler<AddIPAddress, IPAddress>
    {
        private readonly DataContext _dbContext;

        public AddIPAddressHandler(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IPAddress> Handle(AddIPAddress request, CancellationToken ct)
        {
            var ipAddress = _dbContext.IPAddresses.Add(request._ipAddress);
            await _dbContext.SaveChangesAsync();

            return null;
        }
    }
}
