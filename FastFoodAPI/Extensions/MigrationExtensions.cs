using Microsoft.EntityFrameworkCore;
using FastFoodAPI.Entities;

namespace FastFoodAPI.Extensions {
    /// <summary>
    /// Provides extension methods for applying database migrations.
    /// </summary>
    public static class MigrationExtensions {

        /// <summary>
        /// Applies pending migrations to the database.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance used to configure the application.</param>
        /// <remarks>
        /// This method creates a service scope to resolve the <see cref="FastFoodDbContext"/> and applies any pending migrations.
        /// It should be called during application startup to ensure the database schema is up-to-date.
        /// </remarks>
        public static void ApplyMigrations(this IApplicationBuilder app) {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using FastFoodDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<FastFoodDbContext>();

            
            dbContext.Database.Migrate();
        }
    }
}
