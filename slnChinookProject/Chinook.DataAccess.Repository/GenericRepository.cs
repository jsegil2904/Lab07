using Chinook.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository
{
    public class GenericRepository<TEntity> :
        IGenericRepository<TEntity> where
        TEntity : class
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext pContext)
        {
            this.context = pContext;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public int Count()
        {
            return this.context.Set<TEntity>().Count();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public TEntity GetByid(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
