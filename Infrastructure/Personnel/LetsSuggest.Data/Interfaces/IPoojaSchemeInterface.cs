using System;
using System.Collections.Generic;
using Jainism.Core.PoojaDetail;

namespace Jainism.Data.Interfaces
{
    public interface IPoojaSchemeInterface : IEntityRepository<PoojaScheme>
    {
        Boolean checkOverlapDate(PoojaScheme poojaScheme);
        IEnumerable<PoojaScheme> getSchemes();
        PoojaScheme getSchemes(int poojaSchemeId);
        void deleteScheme(int poojaSchemeId);
    }
}
