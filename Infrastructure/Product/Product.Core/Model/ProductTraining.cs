using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductTraining
    {
        [Key]
        public int ProductTrainingId { get; set; }
        public int TrainingId { get; set; }
        public int ProductId { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        public  Training Training { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
