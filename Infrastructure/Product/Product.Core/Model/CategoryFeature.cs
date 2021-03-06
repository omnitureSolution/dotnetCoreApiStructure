using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class CategoryFeature
    {
        [Key]
        public int CategoryFeatureId { get; set; }
        public int CategoryId { get; set; }
        public string FeatureDescription { get; set; }
        public  Category Category { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
