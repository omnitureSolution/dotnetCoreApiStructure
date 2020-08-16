using Jainism.Context;
using Jainism.Core;
using Jainism.Core.Model;
using Jainism.Core.Interfaces;

namespace Jainism.Data.Repository
{
    public class BussSpecializationRepository : GenericRepository<IJainismContext, BusinessSpecialization>, IBussSpecializationInterface
    {
        //private readonly JainismContext _context;
        public BussSpecializationRepository(IUnitOfWork<IJainismContext> uow) : base(uow)
        {
            //_context = uow.Context as JainismContext;
        }
    }
}