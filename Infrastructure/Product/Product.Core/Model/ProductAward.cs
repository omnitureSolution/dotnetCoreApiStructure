using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductAward
    {
        [Key]
        public int ProductAwardId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
