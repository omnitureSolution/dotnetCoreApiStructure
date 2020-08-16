using System;
using System.Collections;
using System.Collections.Generic;
using Jainism.Core.CustomLibrary;
using Jainism.Core.Personnel;

namespace Jainism.Data.Interfaces
{
    public interface ILstPersonnelGroupInterface : IEntityRepository<lstPersonnelGroup>
    {
        IEnumerable GetGroupDetails(Int32 groupId);
        IEnumerable GetPersonnelWithoutGroup();
        ICollection<lstPersonnelGroup> GetGroups(GroupsOption groupOptions);
    }
}
