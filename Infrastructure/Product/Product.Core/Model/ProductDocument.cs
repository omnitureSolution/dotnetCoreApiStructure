using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductDocument
    {
        [Key]
        public int ProductDocumentId { get; set; }
        public int ProductId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
