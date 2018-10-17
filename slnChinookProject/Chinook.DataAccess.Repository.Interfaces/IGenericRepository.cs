using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Repository.Interfaces
{
    public interface 
            IGenericRepository<TEntity>
                where TEntity: class
    {
        TEntity GetByid(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        int Count();
    }
}
