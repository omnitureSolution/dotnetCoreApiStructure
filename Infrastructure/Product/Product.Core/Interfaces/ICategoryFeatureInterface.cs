using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Core.Interfaces
{
    public interface ICategoryFeatureInterface : IEntityRepository<CategoryFeature>
    {
        void InsertOrUpdateGraph(CategoryFeature categoryFeaturegraph);
    }
}
