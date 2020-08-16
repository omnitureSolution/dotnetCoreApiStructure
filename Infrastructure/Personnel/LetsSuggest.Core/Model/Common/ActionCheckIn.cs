using System;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class ActionCheckIn : BaseEntity
    {
        public int ActionCheckInId { get; set; }

        public int? BusinessId { get; set; }

        public int? EventId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }

        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByName { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByName { get; set; }
    }
}
