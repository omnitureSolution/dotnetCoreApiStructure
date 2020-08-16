using System.Collections;
using Jainism.Core.CustomLibrary;
using Jainism.Core.Personnel;

namespace Jainism.Data.Interfaces
{
    public interface IPersonnelGroupRightInterface : IEntityRepository<PersonnelGroupRight>
    {
        IEnumerable GetAllScreens(GroupsOption group);
        void AddGroupRights(AddGroupRights rights);
       
    }
}
