using System;
using System.Collections.Generic;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class GlobalSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Latiude { get; set; }
        public double? Longitude { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int Review { get; set; }
        public decimal? Distance { get; set; }
        public string Categories { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public int SortOrder { get; set; }
        public int RecordType { get; set; }
        public decimal Price { get; set; }
        public decimal? Percentage { get; set; }
        public int Duration { get; set; }   
    }
    public enum ResultTypes
    {
        Pooja = 0,
        Business,
        Event,
        Shoping
    }

    public class GlobalSearchResult
    {
        private ICollection<GlobalSearch> _data;
        public ICollection<GlobalSearch> Data
        {
            get { return (_data ?? (_data = new List<GlobalSearch>())); }
            set { _data = value; }
        }
        public ResultTypes ResultType { get; set; }
        public int SortOrder { get; set; }
        public bool HasMore { get; set; }
    }
}
