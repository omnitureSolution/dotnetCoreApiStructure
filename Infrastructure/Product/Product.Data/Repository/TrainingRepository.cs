using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class TrainingRepository : GenericRepository<IProductContext, Training>, ITrainingInterface
    {
       
        public TrainingRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
          
        }
    }
}
