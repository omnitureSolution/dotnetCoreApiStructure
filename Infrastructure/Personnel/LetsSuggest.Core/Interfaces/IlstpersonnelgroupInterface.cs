using System;
using System.Collections;
using System.Collections.Generic;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface ILstPersonnelGroupInterface : IEntityRepository<LstPersonnelGroup>
    {
        IEnumerable GetGroupDetails(Int32 groupId);
        IEnumerable GetPersonnelWithoutGroup();
        ICollection<LstPersonnelGroup> GetGroups(GroupsOption groupOptions);
        bool IsGroupNameDuplicate(LstPersonnelGroup group);
        LstPersonnel SavePersonalGroup(LstPersonnel employee);
    }
}
