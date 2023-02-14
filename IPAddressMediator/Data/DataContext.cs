using IPAddressMediator.Entities;
using Microsoft.EntityFrameworkCore;
using IPAddressEntity = IPAddressMediator.Entities.IPAddressEntity;

namespace IPAddressMediator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbcontext) : base(dbcontext)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<IPAddressEntity> IPAddresses { get; set; }
    }
}
