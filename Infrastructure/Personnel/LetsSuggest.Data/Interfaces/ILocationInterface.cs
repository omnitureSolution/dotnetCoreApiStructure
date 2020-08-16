using System.Collections;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface ILocationInterface : IEntityRepository<Location>
    {
        Location GetLocation(long locationId);
        long SaveLocation(Location lstLocation);
        IEnumerable SearchLocation(string locationName);

    }
}
