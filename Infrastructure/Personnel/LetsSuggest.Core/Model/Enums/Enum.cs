namespace LetsSuggest.Personnel.Core.Model.Enums
{
    public enum EnumNarrativeType
    {
        History = 1,
        HowToReach = 2,
        Description = 3,
        BusinessDetail = 4,
        BusinessGallery = 5,
        EventGallery = 6,
        EventDetail = 7,
        BusinessAreaSpecialization = 8
    }

    public enum ContactRequestStatus
    {
        Pending = 0,
        Handled = 1
    }

    public enum ModuleType
    {
        Business = 0,
        Event = 1
    }


    public enum BusinessTabs
    {
        Description = 1,
        Hours = 2,
        Reach = 3,
        Contact = 4,
        Gallery = 5,
        History = 6,
        Vihar = 7,
        Books = 8,
        Events = 9,
        Menu = 10,
        Trust = 11,
        Committee = 12
    }

    public enum SearchOrder
    {
        BestMatch = 0,
        MostReviwed = 1,
        TopReviwed = 2,
        Distance = 3
    }

    public enum EventSearchOn
    {
        Live = 0,
        UpcomingLive = 1,
        Offline = 2
    }

    public enum ReviewSortOrder
    {
        NewestFirst = 0,
        OldestFirst = 1,
        HighestRated = 2,
        LowestRated = 3
    }
}
