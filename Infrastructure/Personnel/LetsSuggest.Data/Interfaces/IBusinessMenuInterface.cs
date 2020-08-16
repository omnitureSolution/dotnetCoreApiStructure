using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IBusinessMenuInterface : IEntityRepository<Businessmenu>
    {
        List<ComboModel> GetFoodType();
    }
}
