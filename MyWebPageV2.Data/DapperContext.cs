using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyWebPageV2.Data.Interfaces.Dapper;
using MyWebPageV2.Data.Models.Settings;

namespace MyWebPageV2.Data
{
    public class DapperContext : IDapperContext
    {
        public DatabaseSettings Settings { get; set; }
        public DapperContext(IOptions<DatabaseSettings> databaseSettings)
        {
            Settings = databaseSettings.Value;
        }
        public async Task<SqlConnection> GetConnectionAsync()
        {
            SqlConnection sqlConnection = new SqlConnection(Settings.ConnectionString);

            await sqlConnection.OpenAsync();

            return sqlConnection;
        }
    }
}
