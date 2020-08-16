using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lsticon : BaseEntity
    {
        [Key]
        public int IconId { get; set; }
        public string IconPath { get; set; }

        public string AlterIconPath { get; set; }
        public string Name { get; set; }
        public bool? IsCategory { get; set; }
        public bool? IsActionButton { get; set; }
        public bool? IsQuickLink {get; set; }
    }
}
