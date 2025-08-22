using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RealEstatePortal.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RealEstateDbContext>
    {
        public RealEstateDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RealEstateDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new RealEstateDbContext(optionsBuilder.Options);
        }
    }
}
