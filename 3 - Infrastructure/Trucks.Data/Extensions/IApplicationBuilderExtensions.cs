using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Trucks.Data.Context;
using Trucks.Domain.Models;

namespace Trucks.Data.Extensions
{
    /// <summary>
    /// Add IApplicationBuilder extension to configure end users applications
    /// </summary>
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Apply migration on the Database from the context.
        /// </summary>
        /// <param name="app"> IApplicationBuilder </param>
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var database = scope
                    .ServiceProvider
                    .GetRequiredService<TrucksAppDbContext>()
                    .Database;
                
                if (database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    database
                        .Migrate();
                }
            }
        }
    }
}