using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductDetails :BaseEntity
    {
        public ProductDetails()
        {
            this.ProductCustomers = new List<ProductCustomer>();
            this.ProductDeployments = new List<ProductDeployment>();
            this.ProductDocuments = new List<ProductDocument>();
            this.ProductKeywords = new List<ProductKeyword>();
            this.ProductLinks = new List<ProductLink>();
            this.ProductPayments = new List<ProductPayment>();
            this.ProductReviews = new List<ProductReview>();
            this.ProductSupports = new List<ProductSupport>();
            this.ProductTrainings = new List<ProductTraining>();
        }
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }
        public string LogoName { get; set; }
        public Nullable<bool> IsFreeDemo { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<int> NoOfClients { get; set; }
        public string Version { get; set; }
        public string VideoUrl { get; set; }
        public Nullable<int> CustomerSize { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public int ApprovedBy { get; set; }
        public System.DateTime ApprovedOn { get; set; }
        public Nullable<int> LaunchYear { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public  Category Category { get; set; }
        public  Vendor Vendor { get; set; }
      
        public  ICollection<ProductCustomer> ProductCustomers { get; set; }
        public  ICollection<ProductDeployment> ProductDeployments { get; set; }
        public  ICollection<ProductDocument> ProductDocuments { get; set; }
        public  ICollection<ProductKeyword> ProductKeywords { get; set; }
        public  ICollection<ProductLink> ProductLinks { get; set; }
        public  ICollection<ProductPayment> ProductPayments { get; set; }
        public  ICollection<ProductReview> ProductReviews { get; set; }
        public  ICollection<ProductSupport> ProductSupports { get; set; }
        public  ICollection<ProductTraining> ProductTrainings { get; set; }
    }
}
