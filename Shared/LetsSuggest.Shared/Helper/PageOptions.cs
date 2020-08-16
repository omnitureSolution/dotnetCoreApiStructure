namespace LetsSuggest.Shared.Helper
{
    public class PageOptions
    {
        public int PageNumber { get; set; } = 1;

        private int _pagesize = 50;
        public int PageSize
        {
            get => _pagesize;
            set => _pagesize = value > _pagesize ? _pagesize : value;
        }
    }
}
