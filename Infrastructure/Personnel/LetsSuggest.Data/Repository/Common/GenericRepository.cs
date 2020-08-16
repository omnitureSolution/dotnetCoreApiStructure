using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LetsSuggest.Context;
using LetsSuggest.Core.Interfaces;
using LetsSuggest.Core.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace LetsSuggest.Data.Repository.Common
{
    public abstract class GenericRepository<TC, T> :
      IEntityRepository<T> where T : class where TC : IContext, IDisposable
    {
        protected readonly TC Context;
        internal readonly DbSet<T> DbSet;
         IUnitOfWork<TC> _uow;
        protected GenericRepository(IUnitOfWork<TC> uow)
        {
            this.Context = uow.Context;
            this._uow = uow;
            DbSet = Context.Set<T>();
        }
        public IQueryable<T> All => Context.Set<T>();
        public virtual void Add(T entity)
        {
            Context.SetAdd(entity);
        }
        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties);
        }
        public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<T> results = query.Where(predicate).ToList();
            return results;
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            IEnumerable<T> results = queryable.Where(predicate).ToList();
            return results;
        }
        private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public T Find(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public virtual void Update(T entity)
        {
            Context.SetModified(entity);
        }
        public void InsertGraph(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        //public void UpdateGraph(T entity)
        //{
        //    context.Set<T>().Add(entity);
        //    ContextHelpers.ApplyStateChanges();
        //    //context.ApplyStateChanges(context);
        //}
        public virtual void Delete(int id)
        {
            var entity = Context.Set<T>().Find(id) as BaseEntity;
            if (entity != null)
            {
                entity.IsDeleteProcess = true;
                Context.SetModified(entity);
            }
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
