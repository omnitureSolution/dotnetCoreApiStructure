using System;
using System.Threading.Tasks;

namespace LetsSuggest.Context
{
    public interface IUnitOfWork<TContext> : IDisposable
        where TContext : IContext
    {
        int Save();
        Task<int> SaveAsync();
        TContext Context { get; }

    }
}