using System;
using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    public class LstPersonnelScreen : BaseEntity
    {
        [Key]
        public int ScreenId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public Boolean IsMenu { get; set; }
        public Boolean IsTabConfig { get; set; }
        public Boolean IsApplyRights { get; set; }
        public Boolean IsInsert { get; set; }
        public Boolean IsUpdate { get; set; }
        public Boolean IsDelete { get; set; }
        public Boolean IsView { get; set; }
        public int? ParentScreenId { get; set; }
        public LstPersonnelScreen ParentScreen { get; set; }
    }
}
