using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstcity : BaseEntity
    {
        [Key]
        public int CityId { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
       
    }
}
