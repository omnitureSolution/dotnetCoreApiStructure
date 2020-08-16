using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{

    public class Lstcountry : BaseEntity
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

    }
}
