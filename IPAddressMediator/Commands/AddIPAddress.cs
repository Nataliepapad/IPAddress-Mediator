using IPAddressMediator.Entities;
using IPAddressMediator.IP2CIntegration;
using IPAddressMediator.Persistence;

namespace IPAddressMediator.Commands
{
    public interface IAddIPAddress
    {
        Task<IPAddressEntity> AddIPAddressToDb(IP2CResponse model, string ip, int id);
    }

    public class AddIPAddress : IAddIPAddress
    {
        private readonly IAddIPAddressPersistence _addIPAddressPercistence;

        public AddIPAddress(IAddIPAddressPersistence addIPAddressPercistence)
        {
            _addIPAddressPercistence = addIPAddressPercistence;
        }

        public async Task<IPAddressEntity> AddIPAddressToDb(IP2CResponse model, string ip, int id)
        {
            var ipAddress = new IPAddressEntity
            {
                IP = ip,
                CountryId = id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _addIPAddressPercistence.Persist(ipAddress);
            return ipAddress;
        }
    }
}
