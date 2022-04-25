using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbUp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using MyWebPageV2.Data.Models.Settings;

namespace MyWebPageV2.Migrations
{
    public class MigrationManager : IMigrationManager
    {
        private readonly DatabaseSettings _databaseSettings;
        private readonly ILogger<MigrationManager> _logger;

        public MigrationManager(IOptions<DatabaseSettings> databaseSettings, ILogger<MigrationManager> logger)
        {
            _databaseSettings = databaseSettings.Value;
            _logger = logger;
        }

        public void Execute()
        {
            var database = new MySqlConnectionStringBuilder(_databaseSettings.ConnectionString).Database;


            var upgraderBuilder = DeployChanges.To.MySqlDatabase(_databaseSettings.ConnectionString)
               .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
               .WithTransaction()
               .Build();

            if (upgraderBuilder.IsUpgradeRequired())
            {
                _logger.LogInformation("Database {0} upgrade start. Scripts count", upgraderBuilder.GetScriptsToExecute().Count);

                var result = upgraderBuilder.PerformUpgrade();

                if (result.Successful)
                {
                    _logger.LogInformation("Database {0} upgrade success", database);
                }
                else
                {
                    _logger.LogError("Database {0} upgrade error. {1}", database, result.Error);

                }
            }
            else
            {
                _logger.LogInformation("Database {0} is up to date.", database);
            }
        }
    }
}
