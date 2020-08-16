using System;

namespace LetsSuggest.Personnel.Core.Model.CustomLibrary
{
    public class SearchModel
    {
        public string Keyword { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public decimal Distance { get; set; }
        public int SortOrder { get; set; }
        public int SearchOn { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public DateTime CurrentDate { get; set; }
    }

    public class LocationResult
    {
        public string LocationName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class SearchNameResult
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCategory { get; set; }
        public bool IsSubCategory { get; set; }
        public bool IsBusiness { get; set; }
        public int SortOrder { get; set; }
    }

    public class ReviewSearchModel
    {
        public int BusinessId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Keyword { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; }
        public bool LoadAbuse { get; set; }
        public int SortOrder { get; set; }
    }
}
