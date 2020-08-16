using System;

namespace LetsSuggest.Personnel.Core.Model.Enums
{
    [Flags]
    public enum PersonnelGroupType
    {
        SiteAdmin = 1,
        SiteUser = 2,
        BussinessAdmin = 4,
        Custom = 8,
        PublicUser = 16
    }
}
