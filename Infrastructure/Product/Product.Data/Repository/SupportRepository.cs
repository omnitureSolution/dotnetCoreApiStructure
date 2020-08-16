using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class SupportRepository : GenericRepository<IProductContext, Support>, ISupportInterface
    {
         
        public SupportRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
