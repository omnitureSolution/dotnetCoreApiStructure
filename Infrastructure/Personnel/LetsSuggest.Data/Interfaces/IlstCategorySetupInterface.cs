using System.Collections;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface ILstCategorySetupInterface : IEntityRepository<Confcategorytab>
    {
        IEnumerable GetCategories(int id);
         IEnumerable GetTabSetupList();
    }
}
