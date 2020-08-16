using System.Collections;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface IPinCodeInterface : IEntityRepository<Lstpincode>
    {
        IEnumerable GetPinCodesByCityName(string cname, string pincode);

    }
}
