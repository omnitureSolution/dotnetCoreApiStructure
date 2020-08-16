namespace LetsSuggest.Product.Core.Interfaces
{
    public interface IProductInterface : IEntityRepository<Model.ProductDetails>
    {
        void InsertOrUpdateGraph(Model.ProductDetails productDetails);
    }
}
