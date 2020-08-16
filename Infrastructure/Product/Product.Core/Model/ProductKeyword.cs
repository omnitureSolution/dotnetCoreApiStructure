using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductKeyword
    {
        [Key]
        public int ProductKeywordId { get; set; }
        public int ProductId { get; set; }
        public int KeywordId { get; set; }
        public  Keyword Keyword { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
