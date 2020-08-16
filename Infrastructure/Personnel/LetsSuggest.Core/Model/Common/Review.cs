using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class Review : BaseEntity
    {
        private ICollection<AbuseReview> _abuseReview;
        [Key]
        public int ReviewId { get; set; }
        public int? BusinessId { get; set; }
        public int? EventId { get; set; }
        public string Reviews { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public int? AdminUserId { get; set; }
        public string AdminNotes { get; set; }
        public LstPersonnel lstPersonnel { get; set; }
      
        [NotMapped]
        public bool OwnReview { get; set; }
        [NotMapped]
        public bool IsAbuse { get; set; }
        [NotMapped]
        public ICollection<AbuseReview> AbuseReview
        {
            get { return _abuseReview ?? (_abuseReview = new List<AbuseReview>()); }
            set { _abuseReview = value; }
        }
    }
}
