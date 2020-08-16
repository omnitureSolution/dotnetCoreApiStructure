using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductPayment
    {
        [Key]
        public int ProductPaymentId { get; set; }
        public int ProductId { get; set; }
        public int PaymentId { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> Price { get; set; }
        public  Payment Payment { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
