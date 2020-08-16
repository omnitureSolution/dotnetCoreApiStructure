using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductPaymentRepository : GenericRepository<IProductContext, ProductPayment>, IProductPaymentInterface
    {
        

        public ProductPaymentRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
