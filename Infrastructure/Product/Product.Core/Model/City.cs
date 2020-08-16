using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class City
    {
        [Key]
        public int CityId { get; set; }
        [Required(ErrorMessage = "City name can not be left blank")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "StateID must be provided")]
        public int? StateId { get; set; }
        public State State { get; set; }
        public ICollection<Vendor> Vendors { get; set; }

        [NotMapped]
        public ObjState ObjState { get; set; }
    }

}
