using System.Collections;
using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface ITabsInterface : IEntityRepository<Lsttab>
    {
        IEnumerable GetTabs(PageOptions tabFilter);
        List<ComboModel> GetPrimaryTabs();
        bool IsTabExist(string name, int id);
    }
}
