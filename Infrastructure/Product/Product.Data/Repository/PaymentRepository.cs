using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class PaymentRepository : GenericRepository<IProductContext, Payment>, IPaymentInterface
    {
        
        public PaymentRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
