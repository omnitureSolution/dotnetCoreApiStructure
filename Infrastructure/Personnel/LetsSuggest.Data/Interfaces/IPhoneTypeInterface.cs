using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IPhoneTypeInterface : IEntityRepository<Lstphonetype>
    {
        List<ComboModel> GetPhoneTypesListData();
        bool IsPhoneTypeExist(string name,int id);
    }
}
