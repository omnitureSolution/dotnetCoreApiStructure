using System.Collections;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface ILstCategoryFilterSetupInterface : IEntityRepository<Categoryfilter>
    {
        IEnumerable GetFilterSetupList();
    }
}
