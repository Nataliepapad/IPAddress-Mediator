using IPAddressMediator.Data;
using IPAddressMediator.Entities;

namespace IPAddressMediator.Persistence
{
    public interface IAddIPAddressPersistence
    {
        Task Persist(IPAddressEntity ipAddress);
    }

    public class AddIPAddressPersistence : IAddIPAddressPersistence
    {

        private readonly DataContext _dbContext;

        public AddIPAddressPersistence(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Persist(IPAddressEntity ipAddress)
        {
            _dbContext.IPAddresses.Add(ipAddress);
            await _dbContext.SaveChangesAsync();
        }
    }
}
