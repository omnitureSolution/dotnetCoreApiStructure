using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lsttab : BaseEntity
    {
        [Key]
        public int TabId { get; set; }
        public string TabName { get; set; }
        public string DisplayName { get; set; }
        public string TabDescription { get; set; }
        public long? PrimaryTabId { get; set; }
        public string RoutePath { get; set; }
        public bool? IsVisible { get; set; }
        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByName { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByName { get; set; }
    }
}
