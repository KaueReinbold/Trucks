using Trucks.Data.Context;
using Trucks.Domain.Contracts.Repositories;
using Trucks.Domain.Contracts.UnitOfWork;

namespace Trucks.Data.Persistence
{
    /// <summary>
    /// Class to controls repositories and persistence of data on the Database.
    /// </summary>
    public class UnitOfWork
        : IUnitOfWork
    {
        public TrucksAppDbContext Context { get; }
        public ITruckRepository TruckRepository { get; }

        public UnitOfWork(TrucksAppDbContext context)
        {
            Context = context;

            TruckRepository = new TruckRepository(context);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            TruckRepository.Dispose();
        }
    }
}
