using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trucks.Domain.Contracts.Repositories;

namespace Trucks.Data.Persistence
{
    /// <summary>
    /// Generic Repository patterns implementation to execute actions against the DbContext.
    /// </summary>
    /// <typeparam name="TEntity"> Entity that has DbConfiguration set. </typeparam>
    public class Repository<TEntity>
        : IRepository<TEntity> where TEntity : class
    {

        protected DbContext Context;
        public DbSet<TEntity> Entity { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            Entity = Context.Set<TEntity>();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Add(TEntity entity)
        {
            Entity.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Entity.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Entity.Remove(entity);
        }

        public TEntity Find(int id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = Entity;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }
    }
}
