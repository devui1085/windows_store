using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Business.Interface
{
    public interface IBaseBiz<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity Delete(TEntity entity);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        TEntity Single(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        bool All(Expression<Func<TEntity, bool>> predicate);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        void UpdatePartially(TEntity entity, params Expression<Func<TEntity, object>>[] changedProperties);

    }
}
