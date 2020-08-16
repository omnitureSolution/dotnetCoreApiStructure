using System.Collections;
using Jainism.Core.Personnel;

namespace Jainism.Data.Interfaces
{
    public interface IPersonnelGroupMemberInterface : IEntityRepository<PersonnelGroupMember>
    {
        IEnumerable GetGroupMemeber(int id);
    }
}
