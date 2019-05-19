using Trucks.Domain.Models;

namespace Trucks.Domain.Contracts.Repositories
{
    /// <summary>
    /// Contract to extend the Repository contract to an Entity. 
    /// </summary>
    public interface ITruckRepository
        : IRepository<Truck>
    {
    }
}
