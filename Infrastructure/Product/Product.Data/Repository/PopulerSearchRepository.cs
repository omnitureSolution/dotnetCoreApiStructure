using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class PopulerSearchRepository : GenericRepository<IProductContext, PopulerSearch>, IPopulerSearchInterface
    {
        
        public PopulerSearchRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
