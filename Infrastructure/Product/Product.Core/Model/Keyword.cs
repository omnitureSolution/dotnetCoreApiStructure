using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Keyword
    {
        [Key]
        public int KeywordId { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
