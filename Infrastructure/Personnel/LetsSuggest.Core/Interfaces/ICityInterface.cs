using System.Collections;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface ICityInterface : IEntityRepository<Lstcity>
    {
        IEnumerable GetCitysByStateName(string sname, string name);

    }
}
