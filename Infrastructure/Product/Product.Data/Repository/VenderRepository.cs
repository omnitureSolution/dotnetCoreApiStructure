using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class VendorRepository : GenericRepository<IProductContext, Vendor>, IVendorInterface
    {
        
        public VendorRepository(IUnitOfWork<IProductContext> uow) : base(uow)
        {
           
        }
       
    }
}
