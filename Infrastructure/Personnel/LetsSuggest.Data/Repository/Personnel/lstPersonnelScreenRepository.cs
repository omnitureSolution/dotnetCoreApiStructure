using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Data.Repository.Personnel
{
    public class PersonnelScreenRepository : GenericRepository<ILetsSuggestContext, LstPersonnelScreen>, ILstPersonnelScreenInterface
    {
        public PersonnelScreenRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        }
    }
}
