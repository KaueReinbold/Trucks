using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Trucks.Application.AutoMapper;
using Trucks.Application.Contracts;
using Trucks.Application.Services;

namespace Trucks.Application.Extensions
{
    /// <summary>
    /// Add IServiceCollection extension to configure end users applications
    /// add all dependencies.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Service implementation and auto mapper configuration.
        /// </summary>
        /// <param name="services"> IServiceCollection </param>
        public static void AddApplicationDependencies(
            this IServiceCollection services)
        {

            services.AddScoped<ITruckService, TruckService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
