using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductEnquiry
    {
        [Key]
        public int ProductEnquiryId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Name { get; set; }
        public string BusinessEmail { get; set; }
        public string ContactNo { get; set; }
        public string CompanyName { get; set; }
        public string IndustryName { get; set; }
        public string City { get; set; }
        public string RequirementDetails { get; set; }
        public string Budget { get; set; }
        public Nullable<System.DateTime> EnquiryDate { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
