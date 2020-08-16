using System;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses
{
    public partial class Lstfilters
    {
        [Key]
        public int FilterId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Notes { get; set; }
        public string Lstfilterscol { get; set; }
        public bool? Active { get; set; }
        public bool? Visible { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
