using System.Collections;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Data.Repository.TableManagement
{
    public class CityRepository : GenericRepository<ILetsSuggestContext, Lstcity>, ICityInterface
    {
        
        public CityRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
           
        }

        public IEnumerable GetCitysByStateName(string sname, string name)
        {
            var statelist = Context.Lstcity.Join(Context.Lststate.Where(t => t.Name == sname),
    s => s.StateId,
    c => c.StateId,
    (s, c) => new
    {

        value = s.Name,
        label = s.Name
    }).ToList();
            return statelist;
        }
    }
}
