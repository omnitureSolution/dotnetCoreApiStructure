using System.Collections;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Data.Repository.Personnel
{
   public class PersonnelGroupMemberRepository : GenericRepository<ILetsSuggestContext, PersonnelGroupMember>, IPersonnelGroupMemberInterface
    {
        public PersonnelGroupMemberRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        }


        public IEnumerable GetGroupMemeber(int id)
        {
           return Context.PersonnelGroupRight.ToList();
        }
    }
}
