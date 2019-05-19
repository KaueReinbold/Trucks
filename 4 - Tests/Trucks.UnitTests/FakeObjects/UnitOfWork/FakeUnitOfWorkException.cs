using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trucks.Domain.Contracts.Repositories;
using Trucks.Domain.Contracts.UnitOfWork;
using Trucks.Domain.Models;

namespace Trucks.UnitTests.FakeObjects.UnitOfWork
{
    public class FakeUnitOfWorkWithException
        : IUnitOfWork
    {
        public ITruckRepository TruckRepository { get; }

        public FakeUnitOfWorkWithException()
        {
            TruckRepository = new FakeTruckRepositoryWithException();
        }

        public int Commit()
        {
            return TruckRepository.GetAll().Count();
        }

        public void Dispose() { }
    }

    public class FakeTruckRepositoryWithException
        : ITruckRepository
    {
        public void Add(Truck entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Truck Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Truck> GetAll(Expression<Func<Truck, bool>> filter = null, Func<IQueryable<Truck>, IOrderedQueryable<Truck>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Truck entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Truck entity)
        {
            throw new NotImplementedException();
        }
    }
}
