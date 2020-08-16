using System.ComponentModel.DataAnnotations;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class LstFoodType : BaseEntity
    {
        [Key]
        public int FoodTypeId { get; set; }
        public string Name { get; set; }     
    }
}
