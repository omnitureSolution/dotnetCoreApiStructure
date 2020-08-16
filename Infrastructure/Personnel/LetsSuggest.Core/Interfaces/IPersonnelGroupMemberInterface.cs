using System.Collections;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface IPersonnelGroupMemberInterface : IEntityRepository<PersonnelGroupMember>
    {
        IEnumerable GetGroupMemeber(int id);
    }
}
