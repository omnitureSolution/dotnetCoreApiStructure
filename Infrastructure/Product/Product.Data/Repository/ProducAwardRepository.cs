using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductAwardRepository : GenericRepository<IProductContext, ProductAward>, IProductAwardInterface
    {
        
        public ProductAwardRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
