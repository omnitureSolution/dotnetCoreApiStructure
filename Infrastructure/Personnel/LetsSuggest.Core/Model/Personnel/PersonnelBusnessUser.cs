using System;
using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    public class PersonnelBusinessUser : BaseEntity
    {
        [Key]
        public int PersonnelbusnessuserId { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public Boolean? IsOwner { get; set; }
   
        public LstPersonnel User { get; set; }
    }
}
