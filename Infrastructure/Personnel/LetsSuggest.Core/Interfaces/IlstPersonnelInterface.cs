using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Personnel.Core.Model.Enums;
using LetsSuggest.Personnel.Core.Model.Personnel;
using LetsSuggest.Shared.Helper;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface ILstPersonnelInterface : IEntityRepository<LstPersonnel>
    {
        Task<IEnumerable> GetEmployess(PersonnelOption empFilter);
        Task<lstPersonnelModel> GetPersonnel(Int32 id);
        bool IsEmailExist(string email);
        bool CanAccessBussinessAdmin();
        string GenerateAuthToken(string userId);
        LstPersonnel ValidateLogin(string username, string password);
        LstPersonnel GetPersonnelByEmail(string email);
        String UpdatePassword(ChangePassword changePassword);
      
        IList<ComboModel> GetUserTypes();
        PersonnelGroupType? GetUserType(int? groupId);
    }

}
