using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductCustomer
    {
        [Key]
        public int ProductCustomerId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string LogoUrl { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
