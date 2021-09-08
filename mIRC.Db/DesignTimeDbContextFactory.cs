using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace mIRC.Db
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<mIRCDbContext>
    {

        public mIRCDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../mIRC.Web"))
                   .AddJsonFile($"appsettings{environment}.json").Build();

            var builder = new DbContextOptionsBuilder<mIRCDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new mIRCDbContext(builder.Options);
        }
    }
}
