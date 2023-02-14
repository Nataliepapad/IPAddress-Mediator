using IPAddressMediator.Entities;
using IPAddressMediator.IP2CIntegration;
using IPAddressMediator.Persistence;

namespace IPAddressMediator.Commands
{
    public interface IAddCountry
    {
        Task<Country> AddCountryToDb(IP2CResponse model);
    }

    public class AddCountry : IAddCountry
    {
        private readonly IAddCountryPersistence _addCountryPercistence;

        public AddCountry(IAddCountryPersistence addCountryPercistence)
        {
            _addCountryPercistence = addCountryPercistence;
        }

        public async Task<Country> AddCountryToDb(IP2CResponse model)
        {
            var country = new Country
            {
                Name = model.CountryName,
                TwoLetterCode = model.TwoLetterCode,
                ThreeLetterCode = model.ThreeLetterCode,
                CreatedAt = DateTime.Now
            };

            await _addCountryPercistence.Persist(country);
            return country;
        }
    }
}
