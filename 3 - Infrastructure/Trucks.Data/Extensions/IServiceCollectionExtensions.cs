using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trucks.Data.Context;
using Trucks.Data.Persistence;
using Trucks.Domain.Contracts.Repositories;
using Trucks.Domain.Contracts.UnitOfWork;

namespace Trucks.Data.Extensions
{
    /// <summary>
    /// /// Add IApplicationBuilder extension to configure end users applications
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Configure Repositories and Unit of Work implementations.
        /// </summary>
        /// <param name="services"> IServiceCollection </param>
        public static void AddInfrastructureDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// Configure a database to application.
        /// </summary>
        /// <param name="services"> IServiceCollection </param>
        /// <param name="connectionString"> A connection string is required to add DbContext dependency. </param>
        public static void AddDatabase(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<TrucksAppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// configure a database InMemory.
        /// </summary>
        /// /// <param name="services"> IServiceCollection </param>
        /// <param name="databaseName"> Name for the InMemory database. </param>
        public static void AddDatabaseInMemory(
            this IServiceCollection services,
            string databaseName)
        {
            services.AddDbContext<TrucksAppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName));
        }
    }
}
