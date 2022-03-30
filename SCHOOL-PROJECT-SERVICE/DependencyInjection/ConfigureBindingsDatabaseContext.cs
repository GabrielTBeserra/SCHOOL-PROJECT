using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using System;

namespace SCHOOL_PROJECT_SERVICE.DependencyInjection
{
    public static class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("mysqllocalhost");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 5))));
        }
    }
}