using MyWebPageV2.Data;
using MyWebPageV2.Data.Interfaces.Dapper;
using MyWebPageV2.Data.Models.Settings;
using MyWebPageV2.Migrations;

namespace MyWebPageV2.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterConfigurations(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<DatabaseSettings>(
                    builder.Configuration.GetSection(DatabaseSettings.DatabaseSection));

            return services;
        }

        public static IServiceCollection RegisterMigrationManager(this IServiceCollection services)
        {
            services.AddSingleton<IMigrationManager, MigrationManager>();

            return services;
        }

        public static IServiceCollection RegisterDatabaseContext(this IServiceCollection services)
        {
            services.AddScoped<IDapperContext, DapperContext>();

            return services;
        }
    }
}
