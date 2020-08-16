using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Support
    {
        public Support()
        {
            this.ProductSupports = new List<ProductSupport>();
        }
        [Key]
        public int SupportId { get; set; }
        public string SupportName { get; set; }
        public  ICollection<ProductSupport> ProductSupports { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
