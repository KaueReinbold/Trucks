using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Trucks.Application.Contracts;
using Trucks.Application.ViewModels;
using Trucks.Domain.Contracts.UnitOfWork;
using Trucks.Domain.Models;

namespace Trucks.Application.Services
{
    /// <summary>
    /// Truck Service that will perform actions against Unit of Work class.
    /// </summary>
    public class TruckService
        : ITruckService
    {
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public TruckService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Add(TruckViewModel truckViewModel)
        {
            var truck = Mapper.Map<Truck>(truckViewModel);

            UnitOfWork.TruckRepository.Add(truck);

            UnitOfWork.Commit();
        }

        public void Update(TruckViewModel truckViewModel)
        {
            var truck = Mapper.Map<Truck>(truckViewModel);

            UnitOfWork.TruckRepository.Update(truck);

            UnitOfWork.Commit();
        }

        public void Remove(int id)
        {
            var truck = UnitOfWork.TruckRepository.Find(id);

            UnitOfWork.TruckRepository.Remove(truck);

            UnitOfWork.Commit();
        }

        public List<TruckViewModel> GetAll()
        {
            var trucks = UnitOfWork.TruckRepository.GetAll(orderBy: o => o.OrderBy(t => t.Id));

            var trucksViewModel = Mapper.Map<List<TruckViewModel>>(trucks);

            return trucksViewModel;
        }

        public TruckViewModel Find(int id)
        {
            var truck = UnitOfWork.TruckRepository.Find(id);

            var truckViewModel = Mapper.Map<TruckViewModel>(truck);

            return truckViewModel;
        }
    }
}
