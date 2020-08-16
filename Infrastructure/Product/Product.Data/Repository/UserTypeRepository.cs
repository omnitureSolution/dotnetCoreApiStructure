using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class UserTypeRepository : GenericRepository<IProductContext, UserType>, IUserTypeInterface
    {
        

        public UserTypeRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
