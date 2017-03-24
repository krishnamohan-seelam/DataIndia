using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIndia.Repository
{
    public class DataRepository<TEntity> : IDataRepository<TEntity>, IDisposable where TEntity : class
    {
        protected DbSet<TEntity> EntitySet;
        protected readonly DbContext Context;
        bool _disposed = false;

        public DataRepository(DbContext inContext)
        {
            Context = inContext;
            EntitySet = Context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            EntitySet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            EntitySet.AddRange(entities);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void  Dispose(bool v)
        {
            if (!_disposed)
            {

                Context.Dispose();

                _disposed = true;

            }
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.Where(predicate);
        }

        public TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.SingleOrDefault(predicate);
        }

        public TEntity Get(int id)
        {
            return EntitySet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return EntitySet.ToList();
        }

        public void Remove(TEntity entity)
        {
            EntitySet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            EntitySet.RemoveRange(entities);
        }

       
    }
}
