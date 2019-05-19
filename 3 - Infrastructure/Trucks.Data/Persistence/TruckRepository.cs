using Microsoft.EntityFrameworkCore;
using Trucks.Domain.Contracts.Repositories;
using Trucks.Domain.Models;

namespace Trucks.Data.Persistence
{
    /// <summary>
    /// Class to add Repository implemtnation to an expecific Entity.
    /// </summary>
    public class TruckRepository
        : Repository<Truck>, ITruckRepository
    {
        public TruckRepository(DbContext context)
            : base(context)
        {

        }
    }
}
