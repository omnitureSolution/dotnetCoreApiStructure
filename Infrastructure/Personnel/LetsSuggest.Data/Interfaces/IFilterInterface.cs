using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IFilterInterface : IEntityRepository<LstFilter>
    {
        bool IsFilterExist(string name, int id);
    }
}
