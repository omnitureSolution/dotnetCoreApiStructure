using System.Collections;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Data.Repository.TableManagement
{
    public class PincodeRepository : GenericRepository<ILetsSuggestContext, Lstpincode>, IPinCodeInterface
    {
        public PincodeRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        }

        public IEnumerable GetPinCodesByCityName(string sname, string name)
        {
            var statelist = Context.Lstpincode.Join(Context.Lstcity.Where(t => t.Name == sname),
                    s => s.CityId,
                    c => c.CityId,
                    (s, c) => new
                    {

                        value = s.PinCode,
                        label = s.PinCode
                    }).ToList();
            return statelist;
        }
    }
}
