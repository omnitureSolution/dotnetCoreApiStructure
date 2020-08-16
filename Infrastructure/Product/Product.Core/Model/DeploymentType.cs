using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class DeploymentType
    {
        [Key]
        public int DeploymentTypeId { get; set; }
        public string DeploymentTypeName { get; set; }
        public  ICollection<ProductDeployment> ProductDeployments { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
