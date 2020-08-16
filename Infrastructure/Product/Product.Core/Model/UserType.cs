using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class UserType
    {
        public UserType()
        {
            this.Users = new List<User>();
        }
        [Key]
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public  ICollection<User> Users { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
    }
}
