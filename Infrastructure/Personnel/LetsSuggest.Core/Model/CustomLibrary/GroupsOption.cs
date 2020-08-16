using System;
using System.Collections.Generic;
using LetsSuggest.Shared.Helper;

namespace LetsSuggest.Personnel.Core.Model.CustomLibrary
{
    public class GroupsOption : PageOptions
    {
        public Int32 GroupId { get; set; }
        public Boolean LoadBussinessAdmin { get; set; }
    }
    public class GroupScreens
    {
        public int GroupRightId { get; set; }
        public int ScreenId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public Boolean IsInsert { get; set; }
        public Boolean IsUpdate { get; set; }
        public Boolean IsDelete { get; set; }
        public Boolean IsView { get; set; }

    }

    public class GroupScreensData
    {
        public Int32 GroupId { get; set; }
        public GroupScreens data { get; set; }
        public List<GroupScreensData> children { get; set; }

    }

    public class AddGroupRights
    {
        public Int32 GroupId { get; set; }
        public List<GroupScreens> children { get; set; }

    }
}
