using BaseDataLayer;
using DomainClasses.PoojaDetail;
using JainismBoundContext;
using JainismUOW.Interfaces;

namespace JainismUOW.Repository
{
    public class PoojaPriceHistoryRepository : GenericRepository<IJainismContext, PoojaPriceHistory>, IPoojaPriceHistoryInterface
    {
        protected PoojaPriceHistoryRepository(IUnitOfWork<IJainismContext> uow) : base(uow)
        {
        }
    }
}
