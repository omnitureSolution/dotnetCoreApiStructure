using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    public class PersonnelGroupMember : BaseEntity
    {
        [Key]
        public int PersonnelgroupmemberId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public LstPersonnel Personnel { get; set; }
        public LstPersonnelGroup Group { get; set; }
    }
}

