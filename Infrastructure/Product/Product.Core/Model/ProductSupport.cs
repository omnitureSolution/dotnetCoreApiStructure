using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductSupport
    {
        [Key]
        public int ProductSupportId { get; set; }
        public int ProductId { get; set; }
        public int SupportId { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        public  Support Support { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
