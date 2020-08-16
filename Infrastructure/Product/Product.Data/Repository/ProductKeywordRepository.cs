using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{

    public class ProductKeywordRepository : GenericRepository<IProductContext, ProductKeyword>, IProductKeywordInterface
    {
        

        public ProductKeywordRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
