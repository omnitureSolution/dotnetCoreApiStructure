using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Personnel.Core.Model.Enums;
using LetsSuggest.Personnel.Core.Model.Personnel;
using Microsoft.EntityFrameworkCore;

namespace LetsSuggest.Personnel.Data.Repository.Personnel
{
    public class PersonnelGroupRightRepository : GenericRepository<ILetsSuggestContext, PersonnelGroupRight>, IPersonnelGroupRightInterface
    {
        public PersonnelGroupRightRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        }
        public IEnumerable<GroupScreensData> GetAllScreens(GroupsOption groupOption)
        {
            var group = Context.PersonnelGroupMember
                               .Where(r => r.UserId == Context.UserInfo.UserId)
                               .Select(t => t.Group)
                               .OrderBy(r => r.GroupType).FirstOrDefault();
            if (group == null)
                return Enumerable.Empty<GroupScreensData>();

            if (groupOption.GroupId == 0)
                groupOption.GroupId = group.GroupId;
            IList<int> screenIds;

            if (group.GroupType == PersonnelGroupType.SiteAdmin)
                screenIds = Context.LstPersonnelScreen.Where(r => r.DeletedDate == null && r.ParentScreenId != null).Select(t => t.ScreenId).ToList();

            else
                screenIds = Context.PersonnelGroupRight.Include(r => r.Screen).Where(rights => rights.GroupId == group.GroupId)
                      .Select(s => s.Screen.ScreenId).ToList();

            var list = Context.LstPersonnelScreen.Where(s => s.ParentScreenId == null)
                .Select(parent => new GroupScreensData
                {
                    GroupId = groupOption.GroupId,
                    data = new GroupScreens
                    {
                        ScreenId = parent.ScreenId,
                        ScreenCode = parent.ScreenCode,
                        ScreenName = parent.ScreenName
                    },
                    children = Context.LstPersonnelScreen
                        .Where(em => em.ParentScreenId == parent.ScreenId && screenIds.Any(r => r == em.ScreenId))
                        .Select(child => new GroupScreensData
                        {
                            data = new GroupScreens
                            {
                                ScreenId = child.ScreenId,
                                ScreenCode = child.ScreenCode,
                                ScreenName = child.ScreenName
                            }
                        }).ToList()
                }).Where(l => l.children.Any()).ToList();

            var assignList = Context.PersonnelGroupRight.Where(t => t.GroupId == groupOption.GroupId);

            foreach (var screen in assignList)
            {
                if (!list.Any(t => t.data.ScreenId == screen.ScreenID))
                {
                    var childScreen = list.SelectMany(r => r.children).FirstOrDefault(t => t.data.ScreenId == screen.ScreenID);
                    if (childScreen != null)
                    {
                        childScreen.data.GroupRightId = screen.GroupRightId;
                        childScreen.data.IsDelete = screen.IsDelete;
                        childScreen.data.IsUpdate = screen.IsUpdate;
                        childScreen.data.IsInsert = screen.IsInsert;
                        childScreen.data.IsView = screen.IsView;
                    }
                }
            }
            return list;
        }
        public void AddGroupRights(AddGroupRights rights)
        {
            var rightList = rights.children.Select(k => new PersonnelGroupRight()
            {
                GroupRightId = k.GroupRightId,
                GroupId = rights.GroupId,
                ScreenID = k.ScreenId,
                IsInsert = k.IsInsert,
                IsUpdate = k.IsUpdate,
                IsDelete = k.IsDelete,
                IsView = k.IsView,
                IsAll = k.IsInsert && k.IsUpdate && k.IsDelete && k.IsView

            }).Where(t => (t.IsInsert || t.IsUpdate || t.IsDelete || t.IsView)).ToList();

            var removeChildList = this.Context.PersonnelGroupRight.Where(p => p.GroupId == rights.GroupId
                                                                       && !rightList.Select(a => a.GroupRightId).Contains(p.GroupRightId)
                                                                        ).ToList();
            if (removeChildList.Any())
                this.Context.PersonnelGroupRight.RemoveRange(removeChildList);
            this.Context.PersonnelGroupRight.UpdateRange(rightList);
        }
        public IEnumerable GetMenu()
        {
            var result = Context.PersonnelGroupMember
                .Include(l => l.Group.GroupRights)
                .Where(t => t.UserId == Context.UserInfo.UserId && t.Group.GroupRights.Any(r => r.Screen.IsMenu))
                .Select(t => new
                {
                    rights = t.Group.GroupRights.Select(r => new
                    {
                        r.Screen.ScreenId,
                        r.Screen.ScreenCode,
                        r.IsDelete,
                        r.IsInsert,
                        r.IsUpdate,
                        r.IsView
                    })
                }).FirstOrDefault()?.rights;

            return result;
        }
    }
}
