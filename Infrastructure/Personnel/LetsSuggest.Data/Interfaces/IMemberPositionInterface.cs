using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IMemberPositionInterface : IEntityRepository<Lstmemberposition>
    {
        List<ComboModel> GetMemberPositionListData();
        bool IsPositionExist(string name, int id);
    }
}
