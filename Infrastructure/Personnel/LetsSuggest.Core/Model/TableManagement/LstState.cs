using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lststate : BaseEntity
    {
        [Key]
        public int StateId { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }
    }
}
