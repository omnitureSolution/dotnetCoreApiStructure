using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductCustomerRepository : GenericRepository<IProductContext, ProductCustomer>, IProductCustomerInterface
    {
        
        public ProductCustomerRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
