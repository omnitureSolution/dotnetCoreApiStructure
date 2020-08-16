using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class FeatureRepository : GenericRepository<IProductContext, Feature>, IFeatureInterface
    {
        
        public FeatureRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
