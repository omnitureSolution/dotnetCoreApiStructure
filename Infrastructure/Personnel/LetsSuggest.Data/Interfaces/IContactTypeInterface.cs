using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IContactTypeInterface : IEntityRepository<Lstcontacttype>
    {
        List<ComboModel> GetContactTypesListData();
        bool IsContactTypeExist(string name, int id);
        
    }
}
