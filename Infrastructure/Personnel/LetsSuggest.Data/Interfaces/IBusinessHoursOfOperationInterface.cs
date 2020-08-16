using System.Collections.Generic;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IBusinessHoursOfOperationInterface : IEntityRepository<BusinessHoursOperation>
    {
        void RemoveExisting(int businessId);
        List<BusinessHoursOperation> GetAllTimings(int businessId);
    }
}
