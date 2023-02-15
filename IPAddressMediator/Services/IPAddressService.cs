using IPAddressMediator.Commands;
using IPAddressMediator.Data;
using IPAddressMediator.IP2CIntegration;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace IPAddressMediator.Services
{
    public interface IIPAddressService
    {
        Task<IP2CResponse> GetIPAddressByIp(IPAddress ip);
    }

    public class IPAddressService : IIPAddressService
    {
        private readonly DataContext _dbContext;
        private readonly IAddCountry _addCountry;
        private readonly IAddIPAddress _addIPAddress;
        private readonly IIP2CClient _client;


        public IPAddressService(DataContext dbContext, IAddCountry addCountry, IAddIPAddress addIPAddress, IIP2CClient client)
        {
            _addCountry = addCountry;
            _dbContext = dbContext;
            _addIPAddress = addIPAddress;
            _client = client;
        }

        public async Task<IP2CResponse> GetIPAddressByIp(IPAddress ip)
        {
            var response = await _dbContext.IPAddresses.Include(c => c.Country).FirstOrDefaultAsync(a => a.IP == ip); ;

            if (response == null)
            {
                var httpResponse = await _client.GetIP(ip);

                if (!_dbContext.Countries.Any(x => x.TwoLetterCode == httpResponse.TwoLetterCode))
                {
                    await _addCountry.AddCountryToDb(httpResponse);
                }

                var ID = _dbContext.Countries.Single(x => x.TwoLetterCode == httpResponse.TwoLetterCode).Id;

                await _addIPAddress.AddIPAddressToDb(httpResponse, ip, ID);

                return httpResponse;
            }

            var model = new IP2CResponse(response.Country.Name, response.Country.TwoLetterCode, response.Country.ThreeLetterCode); ;
            return model;
        }
    }
}
