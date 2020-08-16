using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Data.Repository.TableManagement
{
    public class CountryRepository : GenericRepository<ILetsSuggestContext, Lstcountry>, ICountryInterface
    {
       
        public CountryRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        
        }
    }
}
