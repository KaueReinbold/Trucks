using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Trucks.Domain.Contracts.Repositories
{
    /// <summary>
    /// Generic contract to a Repository pattern.
    /// </summary>
    /// <typeparam name="T"> Generic object that will be affact by the implementation. </typeparam>
    public interface IRepository<T>
        : IDisposable where T : class
    {
        void Add(T entity);
        
        void Update(T entity);
        
        void Remove(T entity);
        
        T Find(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
