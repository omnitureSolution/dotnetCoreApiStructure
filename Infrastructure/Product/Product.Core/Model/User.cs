using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
        [NotMapped]
        public String AuthKey { get; set; }
    }
}
