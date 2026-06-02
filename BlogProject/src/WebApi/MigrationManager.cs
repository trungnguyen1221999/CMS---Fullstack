using BlogProject.Data;
using BlogProject.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrationDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<BlogContext>())
                {
                    context.Database.Migrate();
                    new IdentitySeeding().SeedingAsync(context).Wait();
                }
            }
            return app;
        }
    }
}