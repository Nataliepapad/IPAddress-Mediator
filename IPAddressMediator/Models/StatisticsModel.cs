using Microsoft.EntityFrameworkCore;

namespace IPAddressMediator.Models
{
    [Keyless]
    public class StatisticsModel
    {
        public string CountryName { get; set; }

        public int AddressesCount { get; set; }

        public DateTime LastAddressUpdated { get; set; }
    }
}
