﻿using Identity.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Identity.API.Factories
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .AddUserSecrets(Assembly.GetAssembly(typeof(Startup)))
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(config.GetConnectionString("IdentityConnection"), sqlServerOptionsAction: o => o.MigrationsAssembly("Identity.API"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
