using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductTrainingRepository : GenericRepository<IProductContext, ProductTraining>, IProductTrainingInterface
    {
        
        public ProductTrainingRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
