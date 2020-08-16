using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public  ICollection<CategoryFeature> CategoryFeatures { get; set; }
        public  ICollection<Feature> Features { get; set; }
        public  ICollection<ProductDetails> Products { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
