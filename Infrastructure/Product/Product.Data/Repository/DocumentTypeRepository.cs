using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class DocumentTypeRepository : GenericRepository<IProductContext, DocumentType>, IDocumentTypeInterface
    {
        

        public DocumentTypeRepository(IUnitOfWork<IProductContext> uow) : base(uow)
        {
           
        }
    }
}
