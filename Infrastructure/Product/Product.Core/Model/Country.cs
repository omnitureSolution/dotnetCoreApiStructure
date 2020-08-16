using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class Country
    {
        [Key]
        public int CounrtyId { get; set; }
        public string CountryName { get; set; }
        public  ICollection<State> States { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
