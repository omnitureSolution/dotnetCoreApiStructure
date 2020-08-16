using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Payment
    {
        public Payment()
        {
            this.ProductPayments = new List<ProductPayment>();
        }
        [Key]
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public  ICollection<ProductPayment> ProductPayments { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
