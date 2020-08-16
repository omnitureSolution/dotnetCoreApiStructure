using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    public class PersonnelGroupRight : BaseEntity
    {
        [Key]
        public int GroupRightId { get; set; }
        public int GroupId { get; set; }
        public int ScreenID { get; set; }
        public bool IsInsert { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsAll { get; set; }
        public LstPersonnelScreen Screen { get; set; }
    }
}
