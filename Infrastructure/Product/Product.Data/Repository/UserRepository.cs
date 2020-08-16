using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class UserRepository : GenericRepository<IProductContext, User>, IUserInterface
    {
        
        public UserRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
        public void InsertOrUpdateGraph(User user)
        {
            if (user.ObjState == ObjectStateInterfaces.ObjState.Added)
            {
                Context.User.Add(user);
            }
            else
            {
                Context.User.Add(user);
                //context.ApplyStateChanges();
            }
        }
    }
}
