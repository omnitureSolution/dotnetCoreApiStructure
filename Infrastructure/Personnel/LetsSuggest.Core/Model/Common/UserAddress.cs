using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class UserAddress : BaseEntity
    {
        [Key]
        public int UserAddressId { get; set; }
        public string MailingName { get; set; }
        public string PhoneNumber { get; set; }
        public string Locality { get; set; }
        public string Type { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        [NotMapped]
        public string Address
        {
            get
            {
                if (Location != null)
                    return string.Format("{0}, {1}, {2}, {3}-{4}", this.Location.Address, this.Locality, this.Location.CityName, this.Location.StateName, this.Location.PinCode);
                return string.Format("{0}, {1}, Mo: {2}", MailingName, Locality, PhoneNumber);
            }
        }
    }
}
