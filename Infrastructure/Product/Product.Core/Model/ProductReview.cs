using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductReview
    {
        [Key]
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string Prons { get; set; }
        public string Cons { get; set; }
        public Nullable<decimal> OverallRating { get; set; }
        public Nullable<decimal> EasyofUseRating { get; set; }
        public Nullable<decimal> CustomerSupportRating { get; set; }
        public Nullable<decimal> ValueOfMoneyRating { get; set; }
        public Nullable<decimal> FuncationalityRating { get; set; }
        public string SortDescription { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string JobTitle { get; set; }
        public string OrganizationName { get; set; }
        public bool IsApproved { get; set; }
        public System.DateTime ReviewedOn { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
