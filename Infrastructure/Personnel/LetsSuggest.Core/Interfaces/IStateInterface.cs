using System.Collections;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface IStateInterface : IEntityRepository<Lststate>
    {
        IEnumerable GetStatesByCountryName(string cname, string name);

    }
}
