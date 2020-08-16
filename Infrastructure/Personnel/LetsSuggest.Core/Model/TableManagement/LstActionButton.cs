using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstactionbutton : BaseEntity
    {
        [Key]
        public int ActionButtonId { get; set; }
        public string ActionName { get; set; }
        public string DisplayName { get; set; }
        public int? IconId { get; set; }
        [ForeignKey("IconId")]
        public Lsticon Lsticon { get; set; }
        public string Notes { get; set; }
        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByName { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByName { get; set; }
    }
}
