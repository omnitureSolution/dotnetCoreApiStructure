using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    public class PersonnelUserType : BaseEntity
    {
        public int PersonnelUserTypeId { get; set; }
        public int UserId { get; set; }
        public UserAcessType UserType { get; set; }
    }

    public enum UserAcessType
    {
        Employee = 1,
        Coach = 2,
        ShopKeeper = 3

    }
}
