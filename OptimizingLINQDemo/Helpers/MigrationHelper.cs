using Microsoft.EntityFrameworkCore;
using OptimizingLINQDemo.Data;

namespace OptimizingLINQDemo.Helpers
{
    public static class MigrationHelper
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error >>>> {ex}");
                throw;
            }

            return host;
        }
    }
}
