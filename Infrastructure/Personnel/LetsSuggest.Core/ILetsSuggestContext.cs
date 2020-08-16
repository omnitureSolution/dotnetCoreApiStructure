using System.Collections.Generic;
using System.Data.SqlClient;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Common;
using LetsSuggest.Personnel.Core.Model.Personnel;
using LetsSuggest.Personnel.Core.Model.TableManagement;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;

namespace LetsSuggest.Personnel.Core
{
    public interface ILetsSuggestContext : IContext
    {
        IUserInfo UserInfo { get; }


        DbSet<PersonnelGroupMember> PersonnelGroupMember { get; set; }
        DbSet<PersonnelGroupRight> PersonnelGroupRight { get; set; }
        DbSet<PersonnelUserType> PersonnelUserType { get; set; }
        DbSet<Lstactionbutton> Lstactionbutton { get; set; }
        DbSet<Lstagency> Lstagency { get; set; }
        DbSet<Lstbusinesscategory> Lstbusinesscategory { get; set; }
        DbSet<Lstcategoryfilter> Lstcategoryfilter { get; set; }
        DbSet<Lstcategorytab> Lstcategorytab { get; set; }
        DbSet<Lstcity> Lstcity { get; set; }
        DbSet<Lstcontact> Lstcontact { get; set; }
        DbSet<Lstcontacttype> Lstcontacttype { get; set; }
        DbSet<Lstcountry> Lstcountry { get; set; }
        DbSet<Gallery> Gallery { get; set; }
        DbSet<Lstdocumenttype> Lstdocumenttype { get; set; }
        DbSet<LstFilter> Lstfilter { get; set; }
        DbSet<Lstfiltervalue> Lstfiltervalue { get; set; }
        DbSet<LstPersonnelGroup> LstPersonnelGroup { get; set; }
        DbSet<LstPersonnel> LstPersonnel { get; set; }
        DbSet<LstPersonnelScreen> LstPersonnelScreen { get; set; }
        DbSet<Lsticon> Lsticon { get; set; }
        DbSet<Location> Location { get; set; }
        DbSet<Lstmemberposition> Lstmemberposition { get; set; }
        DbSet<Lstphonetype> Lstphonetype { get; set; }
        DbSet<Lstpincode> Lstpincode { get; set; }
        DbSet<Lststate> Lststate { get; set; }
        DbSet<Lsttab> Lsttab { get; set; }
        DbSet<Lstusertitle> Lstusertitle { get; set; }

        DbSet<LstZip> Lstzip { get; set; }


        DbSet<PersonnelBusinessUser> PersonnelBusinessUser { get; set; }


        DbSet<LstFoodType> LstFoodType { get; set; }

        DbSet<LstNearbyCategory> LstNearbyCategory { get; set; }
        DbSet<AbuseReview> AbuseReview { get; set; }

        DbSet<ActionCalendar> ActionCalendar { get; set; }
        DbSet<UserAddress> UserAddress { get; set; }
        DbSet<ActionCheckIn> ActionCheckIn { get; set; }

        List<T> SqlQuery<T>(string query, params SqlParameter[] parameter);
    }


}

