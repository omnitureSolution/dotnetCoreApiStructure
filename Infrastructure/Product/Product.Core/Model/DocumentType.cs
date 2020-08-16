using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class DocumentType
    {
        [Key]
        public int DocumenTypeId { get; set; }
        public string Type { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
