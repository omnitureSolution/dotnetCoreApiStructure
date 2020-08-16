using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Core.Interfaces
{
    public interface IUserInterface : IEntityRepository<User>
    {
        void InsertOrUpdateGraph(User user);
    }
}
