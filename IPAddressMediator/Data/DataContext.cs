using IPAddressMediator.Entities;
using Microsoft.EntityFrameworkCore;
using IPAddress = IPAddressMediator.Entities.IPAddress;

namespace IPAddressMediator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbcontext) : base(dbcontext)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<IPAddress> IPAddresses { get; set; }
    }
}
