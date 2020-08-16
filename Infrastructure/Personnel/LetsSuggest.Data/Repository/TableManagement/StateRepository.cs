using System.Collections;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Data.Repository.TableManagement
{
    public class StateRepository : GenericRepository<ILetsSuggestContext, Lststate>, IStateInterface
    {
        public StateRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        }
        public IEnumerable GetStatesByCountryName(string cname, string name)
        {
            var statelist = Context.Lststate.Join(Context.Lstcountry.Where(t => t.Name == cname),
                s => s.CountryId,
                c => c.CountryId,
                (s, c) => new
                {

                    value = s.Name,
                    label = s.Name
                }).ToList();
            return statelist;
        }
    }
}
