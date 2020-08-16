using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class DeploymentTypeRepository : GenericRepository<IProductContext, DeploymentType>, IDeploymentTypeInterface
    {
        
        public DeploymentTypeRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
