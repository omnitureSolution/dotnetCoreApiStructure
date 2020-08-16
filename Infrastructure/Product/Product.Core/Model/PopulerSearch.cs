using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class PopulerSearch
    {
        [Key]
        public int PopulerSearchId { get; set; }
        public int ProductId { get; set; }
        public System.DateTime SearchOn { get; set; }
        public string SearchIp { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
