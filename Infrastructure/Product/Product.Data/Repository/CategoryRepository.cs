using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class CategoryRepository : GenericRepository<IProductContext, Category>, ICategoryInterface
    {
        
        public CategoryRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
