using System;
using System.Linq;
using System.Linq.Expressions;

namespace LetsSuggest.Product.Core.Interfaces
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        //void InsertGraph(T entity);
        //void UpdateGraph(T entity);
        void Delete(int id);
       
    }
}
