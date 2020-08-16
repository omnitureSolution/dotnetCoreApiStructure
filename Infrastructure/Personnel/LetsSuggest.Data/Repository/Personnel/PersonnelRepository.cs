using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Personnel.Core.Model.Enums;
using LetsSuggest.Personnel.Core.Model.Personnel;
using LetsSuggest.Personnel.Data.Context;
using LetsSuggest.Shared.Crypto;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LetsSuggest.Personnel.Data.Repository.Personnel
{
    public class PersonnelRepository : GenericRepository<ILetsSuggestContext, LstPersonnel>, ILstPersonnelInterface
    {
        private readonly LetsSuggestContext _context;
        readonly IOptions<LoginSetting> _loginSetting;
        readonly IOptions<AuthenticationKeys> _authenticationkeys;

        public PersonnelRepository(IUnitOfWork<ILetsSuggestContext> uow,
                                    IOptions<LoginSetting> loginSetting,
                                    IOptions<AuthenticationKeys> authenticationkeys) : base(uow)
        {

            _context = uow.Context as LetsSuggestContext;
            _loginSetting = loginSetting;
            _authenticationkeys = authenticationkeys;
        }

        #region Override methods
        public override void Delete(int id)
        {
            var person = Find(id);
            person.IsDeleteProcess = true;
            base.Update(person);
        }
        public override void Update(LstPersonnel entity)
        {
            var current = _context.LstPersonnel.AsNoTracking().First(e => e.UserID == entity.UserID);
            if (current.Password != entity.Password)
                entity.Password = HashData.Create(entity.Password, entity.Email);

            var childlist = _context.PersonnelBusinessUser.AsNoTracking().Where(p => p.UserId == entity.UserID
                                                                    && !entity.PersonnelBusinessUser.Select(a => a.BusinessId).Contains(p.BusinessId)).ToList();
            _context.PersonnelBusinessUser.RemoveRange(childlist);
            var groupchildlist = _context.PersonnelGroupMember.AsNoTracking().Where(p => p.UserId == entity.UserID
                                                                         && !entity.PersonnelGroupMembers
                                                                           .Select(a => a.PersonnelgroupmemberId)
                                                                                         .Contains(p.PersonnelgroupmemberId)).ToList();
            _context.PersonnelGroupMember.RemoveRange(groupchildlist);

            var userTypeList = _context.PersonnelUserType.AsNoTracking().Where(p => p.UserId == entity.UserID
                                        && !entity.PersonnelUserTypes.Select(a => a.PersonnelUserTypeId)
                                                .Contains(p.PersonnelUserTypeId)).ToList();
            _context.PersonnelUserType.RemoveRange(userTypeList);

            base.Update(entity);

        }
        public override void Add(LstPersonnel entity)
        {
            entity.Password = HashData.Create(entity.Password, entity.Email);
            base.Add(entity);
        }
        #endregion

        #region ILstPersonnelInterface
        public async Task<IEnumerable> GetEmployess(PersonnelOption empFilter)
        {
            if (empFilter.LoadBussinessAdmin)
            {
                return await _context.LstPersonnel.Where(p => p.DeletedDate == null &&
                     p.PersonnelGroupMembers.Any(r => r.Group.GroupType == PersonnelGroupType.BussinessAdmin))
                    .Skip(empFilter.PageSize * (empFilter.PageNumber - 1))
                    .Take(empFilter.PageSize)
                    .ToListAsync();
            }

            var personnel = _context.LstPersonnel.Include(r => r.PersonnelGroupMembers)
                                    .ThenInclude(l => l.Group)
                                .Include(a => a.PersonnelBusinessUser)
                                .FirstOrDefault(t => t.UserID == Context.UserInfo.UserId);

            var canAccessChild = personnel != null && personnel.PersonnelGroupMembers.Select(r => r.Group).Any(r =>
                                       r.GroupType == PersonnelGroupType.BussinessAdmin ||
                                       r.GroupType == PersonnelGroupType.SiteAdmin);

            return await _context.LstPersonnel.Where(FilterPersonnel(personnel, canAccessChild))
                    .Include(r => r.PersonnelGroupMembers)
                    //.Skip(empFilter.PageSize * (empFilter.PageNumber - 1))
                    //.Take(empFilter.PageSize)
                    .ToListAsync();
        }
        public LstPersonnel ValidateLogin(string username, string password)
        {
            password = HashData.Create(password, username);
            var personnel = _context.LstPersonnel
                .Include(t => t.PersonnelGroupMembers).ThenInclude(t => t.Group)
                .Include(a => a.Gallery)
                .Include(a => a.PersonnelBusinessUser)
                
              .FirstOrDefault(a => a.Email == username && a.DeletedDate == null);
            if (personnel != null)
            {
                if (personnel.Password == password)
                {
                    if (personnel.IsLocked == false)
                    {
                        personnel.LoginAttempt = 0;
                        _context.SaveChanges();
                    }
                    return personnel;
                }
                else if (personnel.Password != password)
                {
                    if (personnel.LoginAttempt >= _loginSetting.Value.MaxAttempt)
                        personnel.IsLocked = true;
                    else
                        personnel.LoginAttempt += 1;
                    _context.SaveChanges();
                }
            }

            return personnel;
        }
        public string GenerateAuthToken(string userId)
        {
            var claims = new[] { new Claim(JwtRegisteredClaimNames.GivenName, userId), new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) };
            var token = new JwtSecurityToken
            (
                issuer: _authenticationkeys.Value.Issuer,
                audience: _authenticationkeys.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationkeys.Value.SigningKey)), SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<lstPersonnelModel> GetPersonnel(Int32 id)
        {
            var personnelModel = new lstPersonnelModel();
            var per = await _context.LstPersonnel
                           .Include(a => a.PersonnelGroupMembers)
                           .Include(a => a.PersonnelUserTypes)
                           .Include(a => a.Gallery)
                           .Include(a => a.PersonnelBusinessUser).FirstOrDefaultAsync(a => a.UserID == id);
            if (per == null) return personnelModel;
            per.CopyTo(personnelModel);
            //personnelModel.CountryName = per.CountryId > 0 ? _context.Lstcountry.Find(per.CountryId).Name : "";
            //personnelModel.StateName = per.StateId > 0 ? _context.Lststate.Find(per.StateId).Name : "";
            //personnelModel.CityName = per.CityId > 0 ? _context.Lstcity.Find(per.CityId).Name : "";
            //personnelModel.ZipCode = per.ZipId > 0 ? _context.Lstpincode.Find(per.ZipId).PinCode : null;


            return personnelModel;
        }
        public bool IsEmailExist(string email)
        {
            return All.Any(a => a.Email == email);
        }
        public bool CanAccessBussinessAdmin()
        {
            return All.Any(a => a.UserID == Context.UserInfo.UserId &&
                a.PersonnelGroupMembers.Any(g => g.Group.GroupType == PersonnelGroupType.SiteAdmin));
        }
        public LstPersonnel GetPersonnelByEmail(string email)
        {
            return All.AsNoTracking().FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }
        public String UpdatePassword(ChangePassword changePassword)
        {
            var personnel = All.FirstOrDefault(x => x.Email.Equals(changePassword.Email, StringComparison.InvariantCultureIgnoreCase));
            if (personnel == null)
                return "Email id not found";
            if (!string.IsNullOrEmpty(changePassword.OTP))
            {
                //if (VerifyOtp(changePassword) != "Success") return string.Empty;
            }
            else
            {
                var key = HashData.Create(changePassword.CurrentPassword, changePassword.Email);
                if (personnel.Password != key)
                    return "Current password mismatch ";
            }
            personnel.Password = HashData.Create(changePassword.NewPassword, changePassword.Email);

            return string.Empty;
        }
     
        public IList<ComboModel> GetUserTypes()
        {
            return Enum.GetValues(typeof(UserAcessType))
                   .Cast<int>().Select(e=>new ComboModel
                    {
                        Value = e,
                          Label = Enum.GetName(typeof(UserAcessType), e)
                   }).ToList();
                   
        }

        public PersonnelGroupType? GetUserType(int? groupId)
        {
            return _context.LstPersonnelGroup.FirstOrDefault(t => t.GroupId == groupId).GroupType;
        }
        #endregion

        #region Private methods
        private Expression<Func<LstPersonnel, bool>> FilterPersonnel(LstPersonnel personnel, Boolean canAccessChild)
        {
            if (!canAccessChild) return per => per.DeletedDate == null && per.UserID == Context.UserInfo.UserId;
            {
                var bussinessIds = personnel.PersonnelBusinessUser.Select(r => r.BusinessId).ToList();

                return per => per.DeletedDate == null &&
                              per.PersonnelBusinessUser.Any(bUser => bussinessIds.Contains(bUser.BusinessId));
            }
        }
        #endregion

    }
}
