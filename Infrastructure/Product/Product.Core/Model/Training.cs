using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Training
    {
        [Key]
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public  ICollection<ProductTraining> ProductTrainings { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
