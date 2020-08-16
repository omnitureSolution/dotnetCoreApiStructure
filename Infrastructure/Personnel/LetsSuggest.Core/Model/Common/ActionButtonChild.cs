using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class ActionButtonChild: BaseEntity
    {
        [Key]
        public int ActionButtonchildId { get; set; }
        public int? BusinessId { get; set; }
        public int? ActionButtonId { get; set; }
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        [ForeignKey("ActionButtonId")]
        public Lstactionbutton Lstactionbutton { get; set; }
        public int? EventId { get; set; }

    }
}
