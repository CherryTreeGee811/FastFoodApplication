using Microsoft.EntityFrameworkCore;
using FastFoodAPI.Entities;


namespace FastFoodAPI.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using FastFoodDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<FastFoodDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
