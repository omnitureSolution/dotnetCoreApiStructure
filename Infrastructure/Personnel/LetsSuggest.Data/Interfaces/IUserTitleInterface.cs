using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IUserTitleInterface : IEntityRepository<Lstusertitle>
    {
        bool IsTitleExist(string name, int id);
    }
}
