using System.Collections;
using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IActionButtonInterface : IEntityRepository<Lstactionbutton>
    {
        IEnumerable GetActionIcons();
        List<ComboModel> GetActionButtonListData();
        bool IsActionNameExist(string name, int id);
    }
}