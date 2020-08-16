using System.Collections.Generic;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface INetworkLogInterface : IEntityRepository<NetworkLog>
    {
        void SaveNetworkLogs(List<NetworkLog> networkLogs);
    }
}
