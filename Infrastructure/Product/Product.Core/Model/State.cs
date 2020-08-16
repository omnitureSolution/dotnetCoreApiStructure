using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class State
    {
        public State()
        {
            this.Cities = new List<City>();
        }
        [Key]
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
        public  ICollection<City> Cities { get; set; }
        public  Country Country { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
