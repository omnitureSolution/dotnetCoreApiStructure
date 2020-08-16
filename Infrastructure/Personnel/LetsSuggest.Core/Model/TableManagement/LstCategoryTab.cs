using System;
using System.ComponentModel.DataAnnotations;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstcategorytab
    {
        [Key]
        public int CategorytabId { get; set; }
        public int? BusinessCategoryId { get; set; }
        public int? Tabid { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
