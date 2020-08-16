using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class SearchHistory
    {
        [Key]
        public int SearchHistoryId { get; set; }
        public string SearchText { get; set; }
        public System.DateTime SearchOn { get; set; }
        public string SearchIp { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
