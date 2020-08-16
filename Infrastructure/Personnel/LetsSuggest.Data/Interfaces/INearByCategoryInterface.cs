using System.Collections;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface INearByCategoryInterface : IEntityRepository<LstNearbyCategory>
    {
        IEnumerable GetNearbySetup();
        void SaveNearbySetup(NearbyCategoryModel nearBycategory);
        void DeleteNearbySetup(LstNearbyCategory nearByCategory);
    }
}
