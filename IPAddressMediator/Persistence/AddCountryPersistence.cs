using IPAddressMediator.Data;
using IPAddressMediator.Entities;

namespace IPAddressMediator.Persistence
{
    public interface IAddCountryPersistence
    {
        Task Persist(Country country);
    }

    public class AddCountryPersistence : IAddCountryPersistence
    {
        private readonly DataContext _dbContext;

        public AddCountryPersistence(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Persist(Country country)
        {
            _dbContext.Countries.Add(country);
            await _dbContext.SaveChangesAsync();
        }
    }
}
