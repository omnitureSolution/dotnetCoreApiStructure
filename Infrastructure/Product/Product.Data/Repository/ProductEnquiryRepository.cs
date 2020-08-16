using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductEnquiryRepository : GenericRepository<IProductContext, ProductEnquiry>, IProductEnquiryInterface
    {
        
        public ProductEnquiryRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
