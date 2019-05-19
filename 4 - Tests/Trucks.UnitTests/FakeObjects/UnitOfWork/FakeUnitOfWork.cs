using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trucks.Domain.Contracts.Repositories;
using Trucks.Domain.Contracts.UnitOfWork;
using Trucks.Domain.Models;
using Trucks.Domain.Models.Enumerables;

namespace Trucks.UnitTests.FakeObjects.UnitOfWork
{
    public class FakeUnitOfWork
        : IUnitOfWork
    {
        public ITruckRepository TruckRepository { get; }

        public FakeUnitOfWork()
        {
            TruckRepository = new FakeTruckRepository();
        }

        public int Commit()
        {
            return TruckRepository.GetAll().Count();
        }

        public void Dispose() { }
    }

    public class FakeTruckRepository
        : ITruckRepository
    {

        public List<Truck> Entities { get; private set; }

        public FakeTruckRepository()
        {
            Entities = new List<Truck>
            {
                new Truck
                {
                    Id = 1001,
                    Chassis = "4V5K99GG84N364357",
                    Model = EnumModel.FH,
                    ModelComplement = "540",
                    Year = DateTime.Today.Year,
                    ModelYear = DateTime.Today.Year + 1
                },
                new Truck
                {
                    Id = 10002,
                    Chassis = "YV4CR852070015620",
                    Model = EnumModel.FM,
                    ModelComplement = "370",
                    Year = DateTime.Today.Year,
                    ModelYear = DateTime.Today.Year + 1
                }
            };
        }

        public void Add(Truck entity)
        {
            entity.Id = Entities.Max(e => e.Id) + 1;

            Entities.Add(entity);
        }

        public void Dispose() { }

        public Truck Find(int id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Truck> GetAll(Expression<Func<Truck, bool>> filter = null, Func<IQueryable<Truck>, IOrderedQueryable<Truck>> orderBy = null)
        {
            IQueryable<Truck> query = Entities.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public void Remove(Truck entity)
        {
            Entities.Remove(entity);
        }

        public void Update(Truck entity)
        {
            var result = Find(entity.Id);

            Remove(result);

            Add(entity);
        }
    }
}
