using System.Collections;
using System.Collections.Generic;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface IPersonnelGroupRightInterface : IEntityRepository<PersonnelGroupRight>
    {
        IEnumerable<GroupScreensData> GetAllScreens(GroupsOption groupOption);
        void AddGroupRights(AddGroupRights rights);
        IEnumerable GetMenu();


    }
}
