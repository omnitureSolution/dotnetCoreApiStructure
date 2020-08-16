using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class CityRepository : GenericRepository<IProductContext, City>, ICityInterface
    {
        
        public CityRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
