using System;
using System.Collections;
using System.Threading.Tasks;
using Jainism.Core.CustomLibrary;
using Jainism.Core.Personnel;

namespace Jainism.Data.Interfaces
{
    public interface ILstPersonnelInterface : IEntityRepository<lstPersonnel>
    {
        IEnumerable GetEmployess(PersonnelOption empFilter);
        Task<lstPersonnelModel> GetPersonnel(Int32 id);
        bool IsEmailExist(string email);
        bool CanAccessBussinessAdmin();
        string GenerateAuthToken(string userId);
        lstPersonnel ValidateLogin(string username, string password);
        IEnumerable GetMenu();
        lstPersonnel GetPersonnelByEmail(string email);
        String UpdatePassword(ChangePassword changePassword);
        string VerifyOTP(ChangePassword changePassword);

    }

}
