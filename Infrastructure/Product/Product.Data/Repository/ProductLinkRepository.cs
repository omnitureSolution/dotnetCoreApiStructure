using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductLinkRepository : GenericRepository<IProductContext, ProductLink>, IProductLinkInterface
    {
        

        public ProductLinkRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
