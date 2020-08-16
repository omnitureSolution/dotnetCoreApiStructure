using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstmemberposition : BaseEntity
    {
        [Key]
        public int MemberPositionId { get; set; }
        public string Name { get; set; }
        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByName { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByName { get; set; }
    }
}
