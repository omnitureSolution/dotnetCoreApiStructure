using System;
using System.ComponentModel.DataAnnotations;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstcontact
    {
        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Contacttype { get; set; }
        public string Email { get; set; }
        public int? Phone1 { get; set; }
        public int? Phone2 { get; set; }
        public int? WhatsappContact { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
