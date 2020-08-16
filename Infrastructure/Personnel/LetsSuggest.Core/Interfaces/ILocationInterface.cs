using System.Collections;
using System.Collections.Generic;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Common;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface ILocationInterface : IEntityRepository<Location>
    {
        Location GetLocation(long locationId);
        int SaveLocation(Location lstLocation);
        IEnumerable SearchLocation(string locationName);
        List<Location> GetMatchedLocation(int stateId, int? cityId, int? zipId, string address);
        UserAddress SaveUserAddress(UserAddress userAddress);
        List<UserAddress> GetUserAddresses();
    }
}
