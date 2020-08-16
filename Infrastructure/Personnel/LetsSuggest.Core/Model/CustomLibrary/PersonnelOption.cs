using System;
using LetsSuggest.Shared.Helper;

namespace LetsSuggest.Personnel.Core.Model.CustomLibrary
{
    public class PersonnelOption : PageOptions
    {
        public Int32 BussinessId { get; set; }
        public Boolean LoadBussinessAdmin { get; set; }
    }

    public class ChangePassword
    {
        public string Email { get; set; }
        public String CurrentPassword { get; set; }
        public String NewPassword { get; set; }
        public string OTP { get; set; }
    }

}
