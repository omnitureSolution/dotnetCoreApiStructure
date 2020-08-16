using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstfiltervalue:BaseEntity
    {
        [Key]
        public int FilterValueId { get; set; }
        public int FilterId { get; set; }
        public string Name { get; set; }     
   
    }
}
