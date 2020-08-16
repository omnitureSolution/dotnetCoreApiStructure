using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class ProductDeployment
    {
        [Key]
        public int ProductDeploymentId { get; set; }
        public int ProductId { get; set; }
        public int DeploymentTypeId { get; set; }
        public string ProductUrl { get; set; }
        public  DeploymentType DeploymentType { get; set; }
        public  ProductDetails ProductDetails { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
