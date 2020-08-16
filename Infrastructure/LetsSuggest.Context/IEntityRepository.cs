using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LetsSuggest.Context
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void InsertGraph(T entity);

    }
}
