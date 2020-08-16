using System;
using System.ComponentModel.DataAnnotations;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class LstZip
    {
        [Key]
        public int ZipcodeId { get; set; }
        public int? CityId { get; set; }
        public string PinCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
