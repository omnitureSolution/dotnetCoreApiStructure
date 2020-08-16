using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Personnel.Core.Model.Enums;
using LetsSuggest.Personnel.Core.Model.Personnel;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;

namespace LetsSuggest.Personnel.Data.Repository.Personnel
{
    public class PersonnelGroupRepository : GenericRepository<ILetsSuggestContext, LstPersonnelGroup>, ILstPersonnelGroupInterface
    {
        private readonly IUserInfo _userInfo;
        public PersonnelGroupRepository(IUnitOfWork<ILetsSuggestContext> uow, IUserInfo userInfo) : base(uow)
        {
            this._userInfo = userInfo;
        }
        public IEnumerable GetGroupDetails(int groupId)
        {
            var bussinessIds = Context.PersonnelBusinessUser.Where(t => t.UserId == _userInfo.UserId).Select(p => p.BusinessId).ToList();
            return Context.LstPersonnelGroup.Where(group => group.GroupId == groupId).Select(group => new
            {
                group.GroupId,
                group.GroupName,
                group.GroupType,
                GroupMember = group.GroupMembers.Where(r => r.Personnel.DeletedDate == null &&
                    r.Personnel.PersonnelBusinessUser.Any(t => bussinessIds.Contains(t.BusinessId))).Select(member => new
                    {
                        PersonnelgroupmemberID = member.PersonnelgroupmemberId,
                        member.Personnel.UserID,
                        fullName = string.Concat(member.Personnel.FirstName, " ", member.Personnel.MiddleName)
                    })
            }).ToList();
        }
        public IEnumerable GetPersonnelWithoutGroup()
        {
            var personel = Context.PersonnelBusinessUser.FirstOrDefault(a => a.UserId == Context.UserInfo.UserId);
            if (personel != null)
            {
                return Context.LstPersonnel.Where(per =>
                                per.PersonnelBusinessUser.Any(a => a.BusinessId == personel.BusinessId) &&
                                !Context.PersonnelGroupMember.Any(g => g.UserId == per.UserID && g.DeletedDate == null)).Select(p => new
                                {
                                    p.UserID,
                                    fullName = string.Concat(p.FirstName, " ", p.MiddleName)
                                }).ToList();
            }
            return new List<LstPersonnel>();
        }
        public ICollection<LstPersonnelGroup> GetGroups(GroupsOption groupOptions)
        {
            if (groupOptions.LoadBussinessAdmin)
                return Context.LstPersonnelGroup.Where(group => group.GroupType == PersonnelGroupType.BussinessAdmin &&
                group.DeletedDate == null).ToList();

            var personnel = Context.LstPersonnel
                .Include(b => b.PersonnelBusinessUser)
                .Include(a => a.PersonnelGroupMembers)
                .ThenInclude(t => t.Group).FirstOrDefault(r => r.UserID == _userInfo.UserId);

            var groupType = personnel?.PersonnelGroupMembers.Select(p => p.Group.GroupType).ToList();

            var groupAccess = GroupAccess(groupType);
            var bussinessIds = personnel?.PersonnelBusinessUser.Select(p => p.BusinessId).ToList();
            return Context.LstPersonnelGroup.Where(group => groupAccess.Contains(group.GroupType) &&
                                                      (bussinessIds.Contains(group.BussinessId.Value) || group.BussinessId == null) &&
                                                       group.DeletedDate == null).Select(a => new LstPersonnelGroup
                                                       {
                                                           GroupId = a.GroupId,
                                                           GroupName = a.GroupName
                                                       }).ToList();

        }
        public bool IsGroupNameDuplicate(LstPersonnelGroup group)
        {
            return All.Any(a => a.GroupName == group.GroupName && a.DeletedDate == null && a.GroupId != group.GroupId);
        }
        public override void Update(LstPersonnelGroup entity)
        {
            var childlist = Context.PersonnelGroupMember.Where(p => p.GroupId == entity.GroupId
                                                                      && !entity.GroupMembers.Select(a => a.PersonnelgroupmemberId).Contains(p.PersonnelgroupmemberId)).ToList();
            Context.PersonnelGroupMember.RemoveRange(childlist);

            var group = Context.LstPersonnelGroup.AsNoTracking().First(r => r.GroupId == entity.GroupId);
            entity.GroupType = group.GroupType;
            base.Update(entity);

        }
        public override void Delete(int id)
        {
            var group = FindByInclude(r => r.GroupId == id, r => r.GroupMembers, r => r.GroupRights).FirstOrDefault();
            if (group == null) return;

            group.IsDeleteProcess = true;

            foreach (var personnelGroupMember in group.GroupMembers)
            {
                personnelGroupMember.IsDeleteProcess = true;
            }
            foreach (var personnelGroupRight in group.GroupRights)
            {
                personnelGroupRight.IsDeleteProcess = true;
            }
            base.Update(group);
        }
        private List<PersonnelGroupType?> GroupAccess(List<PersonnelGroupType?> groupType)
        {
            if (groupType.Contains(PersonnelGroupType.SiteAdmin))
            {
                groupType.AddRange(
                    new PersonnelGroupType?[] {
                    PersonnelGroupType.BussinessAdmin , PersonnelGroupType.SiteAdmin ,
                        PersonnelGroupType.Custom , PersonnelGroupType.SiteUser
                });

            }
            else if (groupType.Contains(PersonnelGroupType.BussinessAdmin))
            {
                groupType.AddRange(
                    new PersonnelGroupType?[] {
                        PersonnelGroupType.BussinessAdmin ,PersonnelGroupType.Custom
                    });

            }
            else if (groupType.Contains(PersonnelGroupType.SiteUser))
            {
                groupType.AddRange(
                    new PersonnelGroupType?[] {
                        PersonnelGroupType.BussinessAdmin ,
                        PersonnelGroupType.Custom , PersonnelGroupType.SiteUser
                    });

            }
            return groupType.Distinct().ToList();

        }
        public LstPersonnel SavePersonalGroup(LstPersonnel employee)
        {
            if (employee.UserRole != null)
            {
                int? groupId = null;
                if (employee.UserRole == (int)PersonnelGroupType.SiteAdmin)
                    groupId = Context.LstPersonnelGroup.FirstOrDefault(group => group.GroupType == PersonnelGroupType.SiteAdmin && group.DeletedDate == null)?.GroupId;
                else if (employee.UserRole == (int)PersonnelGroupType.SiteUser)
                    groupId = Context.LstPersonnelGroup.FirstOrDefault(group => group.GroupType == PersonnelGroupType.SiteUser && group.DeletedDate == null)?.GroupId;
                else if (employee.UserRole == (int)PersonnelGroupType.BussinessAdmin)
                    groupId = Context.LstPersonnelGroup.FirstOrDefault(group => group.GroupType == PersonnelGroupType.BussinessAdmin && group.DeletedDate == null)?.GroupId;
                else if (employee.UserRole == (int)PersonnelGroupType.Custom)
                    groupId = Context.LstPersonnelGroup.FirstOrDefault(group => group.GroupType == PersonnelGroupType.Custom && group.DeletedDate == null)?.GroupId;
                else if (employee.UserRole == (int)PersonnelGroupType.PublicUser)
                    groupId = Context.LstPersonnelGroup.FirstOrDefault(group => group.GroupType == PersonnelGroupType.PublicUser && group.DeletedDate == null)?.GroupId;
                employee.PersonnelGroupMembers = new List<PersonnelGroupMember> { new PersonnelGroupMember { GroupId = Convert.ToInt32(groupId) } };
            }
            return employee;
        }
    }
}
