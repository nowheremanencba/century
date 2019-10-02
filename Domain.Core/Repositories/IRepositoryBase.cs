using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IRepositoryBase<TEntity>
               where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();        
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        void Commit();
        void LoadReference(TEntity obj, Expression<Func<TEntity, object>> reference);
        void LoadCollection(TEntity obj, Expression<Func<TEntity, IEnumerable<object>>> collection);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
