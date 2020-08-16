using System;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    public class LoginModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean IsAdminLogin { get; set; }
    }
}
