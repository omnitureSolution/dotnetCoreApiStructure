using System.Collections.Generic;
using Jainism.Core;
using Jainism.Core.CustomLibrary;

namespace Jainism.Data.Interfaces
{

    public interface IEventInterface : IEntityRepository<Event>

    {
        IEnumerable<EventModel> SearchEvent(SearchModel search);
        object GetEventDetail(int EventId);

    }
}
