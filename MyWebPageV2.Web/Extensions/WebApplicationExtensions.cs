using MyWebPageV2.Migrations;

namespace MyWebPageV2.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void RunMigrations(this WebApplication webApplication)
        {
            var migrationManager = webApplication.Services.GetRequiredService<IMigrationManager>();

            migrationManager.Execute();
        }
    }
}
