using CarbonNow.Model;
using Microsoft.EntityFrameworkCore;

namespace CarbonNow.Data
{
    public class CarbonNowDbContext : DbContext
    {

        public CarbonNowDbContext(DbContextOptions<CarbonNowDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<ElectricalItem> ElectricalItems { get; set; }

    }
}
