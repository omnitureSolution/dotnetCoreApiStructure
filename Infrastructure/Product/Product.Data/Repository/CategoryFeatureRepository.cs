using LetsSuggest.Context;
using ObjectStateInterfaces;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class CategoryFeatureRepository : GenericRepository<IProductContext, CategoryFeature>, ICategoryFeatureInterface
    {
        

        public CategoryFeatureRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
        public void InsertOrUpdateGraph(CategoryFeature categoryFeaturegraph)
        {
            if (categoryFeaturegraph.ObjState == ObjState.Added)
            {
                Context.CategoryFeature.Add(categoryFeaturegraph);
            }
            else
            {
                Context.CategoryFeature.Add(categoryFeaturegraph);
                //Context.ApplyStateChanges();
            }
        }
       
    }
}
