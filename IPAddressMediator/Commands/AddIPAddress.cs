using IPAddressMediator.Data;
using IPAddressMediator.Entities;
using MediatR;

namespace IPAddressMediator.Commands
{
    public class AddIPAddress : IRequest<IPAddress>
    {
        private readonly DataContext _dbContext;

        public AddIPAddress(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task AddIPAddressToDb(IPAddress model)
        {
            var ipAdrress = new IPAddress
            {
                IP = model.IP,
                CountryId = model.CountryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Country = model.Country,
            };

            _dbContext.IPAddresses.Add(model);
            await _dbContext.SaveChangesAsync();

        }
    }
}
