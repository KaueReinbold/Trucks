using System.Collections.Generic;
using Trucks.Application.ViewModels;

namespace Trucks.Application.Contracts
{
    /// <summary>
    /// Contract to specified the action for Truck service.
    /// </summary>
    public interface ITruckService
    {
        void Add(TruckViewModel truckViewModel);
        void Update(TruckViewModel truckViewModel);
        void Remove(int id);
        List<TruckViewModel> GetAll();
        TruckViewModel Find(int id);
    }
}
