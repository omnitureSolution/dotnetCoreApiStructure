using System.Threading.Tasks;

namespace LetsSuggest.Context
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : IContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public TContext Context => _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
