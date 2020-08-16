using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductRepository : GenericRepository<IProductContext, ProductDetails>, IProductInterface
    {
        

        public ProductRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
        public void InsertOrUpdateGraph(ProductDetails product)
        {
            if (product.ObjState == ObjectStateInterfaces.ObjState.Added)
            {
                Context.ProductDetails.Add(product);
            }
            else
            {
                Context.ProductDetails.Add(product);
                //context.ApplyStateChanges();
            }
        }
     
    }
}
