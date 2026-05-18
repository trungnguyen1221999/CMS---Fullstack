using BlogProject.Data;
using BlogProject.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrationDataBase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<BlogContext>())
                {
                    context.Database.Migrate();
                    new IdentitySeeding().Seeding(context).Wait();
                }
            }
            return app;
        }
    }
}