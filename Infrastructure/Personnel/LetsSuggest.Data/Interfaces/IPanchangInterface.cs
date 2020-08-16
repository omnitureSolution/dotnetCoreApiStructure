using System;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IPanchangInterface : IEntityRepository<Panchang>
    {
        object GetPanchangDetail(DateTime date, string riseTime, string setTime, string navkarsiTime, string porsiTime, string sadhporsiTime, string purimaddhaTime, string avadhhaTime, string chauviharTime);
    }

}
