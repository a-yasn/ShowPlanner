using Microsoft.Extensions.Configuration;
using ShowPlanner.Infrastructure;
using System;

namespace ShowPlanner.DAL.Dapper
{
    public class ConfigService : IConfigService
    {
        private string connectionString;

        public ConfigService()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
