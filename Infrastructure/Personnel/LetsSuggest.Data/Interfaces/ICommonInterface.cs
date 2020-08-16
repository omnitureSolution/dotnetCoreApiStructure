using System.Collections;
using Jainism.Core.CustomLibrary;

namespace Jainism.Data.Interfaces
{
    public interface ICommonInterface : IEntityRepository<HomePageDetail>
    {
        HomePageDetail HomePageDetail();
        IEnumerable GetNearByLocation(int BusinessId);
    }
}
