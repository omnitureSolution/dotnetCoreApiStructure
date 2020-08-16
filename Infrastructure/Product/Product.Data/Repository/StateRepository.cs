using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class StateRepository : GenericRepository<IProductContext, State>, IStateInterface
    {
        
        public StateRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
