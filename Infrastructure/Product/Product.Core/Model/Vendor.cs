using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Vendor
    {
        public Vendor()
        {
            this.Products = new List<ProductDetails>();
        }
        [Key]
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Pincode { get; set; }
        public int? CityId { get; set; }
        public string BusinessConcatNo { get; set; }
        public string BusinessEmail { get; set; }
        public  City City { get; set; }
        public  ICollection<ProductDetails> Products { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
