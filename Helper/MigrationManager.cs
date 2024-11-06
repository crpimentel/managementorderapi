using managementorderapi.Data;
using Microsoft.EntityFrameworkCore;

namespace managementorderapi.Helper
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication WebApp) {

            try {
                using (var scope = WebApp.Services.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                    {
                        appContext.Database.Migrate();
                    }
                }
            }
            catch ( Exception ex) 
            {
                throw;
            }
            return WebApp;
        }
        
    }
}
