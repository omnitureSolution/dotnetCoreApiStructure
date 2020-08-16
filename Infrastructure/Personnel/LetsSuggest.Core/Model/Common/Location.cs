using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.TableManagement;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class Location : BaseEntity
    {
        [Key]
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int StateId { get; set; }
        public int? CountryId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? PincodeId { get; set; }
        [ForeignKey("StateId")]
        public Lststate Lststate { get; set; }
        [ForeignKey("CountryId")]
        public Lstcountry Lstcountry { get; set; }
        [ForeignKey("CityId")]
        public Lstcity Lstcity { get; set; }
        [ForeignKey("PincodeId")]
        public Lstpincode Lstpincodes { get; set; }

        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string CityName { get; set; }

        [NotMapped]
        public string PinCode { get; set; }
    }
}
