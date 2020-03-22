using System.IO;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
             IConfigurationRoot configuration = new ConfigurationBuilder().Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = "Server=localhost;Database=BookStore; User Id=SA;Password=Admin2020; ";

            builder.UseSqlServer(connectionString);       

            return new ApplicationDbContext(builder.Options);
        }
    }
}