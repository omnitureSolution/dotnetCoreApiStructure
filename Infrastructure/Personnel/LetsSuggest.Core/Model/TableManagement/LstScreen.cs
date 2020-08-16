using System.ComponentModel.DataAnnotations;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class LstScreen
    {
        [Key]
        public int ScreenId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public int UserTypeId { get; set; }
        public int? ParentScreenId { get; set; }
        public string UrlPath { get; set; }
        public bool IsMenu { get; set; }
        public bool IsToolbar { get; set; }
        public bool IsUserMenu { get; set; }
        public bool IsApplyRights { get; set; }
        public bool IsInsert { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsExternal { get; set; }
        public bool IsPopup { get; set; }
        public bool? CanAttachDoc { get; set; }
    }
}
