using System;
using Trucks.Domain.Contracts.Repositories;

namespace Trucks.Domain.Contracts.UnitOfWork
{
    /// <summary>
    /// Contract to set the actions for the Unit of Work pattern.
    /// </summary>
    public interface IUnitOfWork
        : IDisposable
    {
        ITruckRepository TruckRepository { get; }
        int Commit();
    }
}
