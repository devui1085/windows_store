using System;
using Store.Business.Interface;
using Store.DataAccess.Context;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Store.Business.Core
{
    public class BaseBiz<TEntity> : IBaseBiz<TEntity> where TEntity : class
    {
        private readonly WindowsStoreContext _context;

        public BaseBiz(WindowsStoreContext context)
        {
            _context = context;
        }

        public TEntity Create(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            var set = _context.Set<TEntity>();
            set.Attach(entity);
            return _context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var set = _context.Set<TEntity>();
            
            if (includes != null)
            {
                foreach (var include in includes)
                {
                  //  var propertyName = GetPropertyName(include);
                    set.Include(include);
                }
            }

            return set;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    set.Include(include);
                }
            }

            return set.SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    set.Include(include);
                }
            }

            return set.Where(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public bool All(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().All(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = _context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    set.Include(include);
                }
            }
            return set.Single(predicate);
        }

        public void UpdatePartially(TEntity entity, params Expression<Func<TEntity, object>>[] changedProperties)
        {
            var set = _context.Set<TEntity>();
            set.Attach(entity);

            foreach (var property in changedProperties)
            {
                _context.Entry(entity).Property(property).IsModified = true;
            }
        }

        private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            MemberExpression memberExpr = expression.Body as MemberExpression;
            if (memberExpr == null)
                throw new ArgumentException("Expression body must be a member expression");
            return memberExpr.Member.Name;
        }
    }
}
