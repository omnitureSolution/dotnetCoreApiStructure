using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class AbuseReview : BaseEntity
    {
        public int AbuseReviewId { get; set; }
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    }
}
