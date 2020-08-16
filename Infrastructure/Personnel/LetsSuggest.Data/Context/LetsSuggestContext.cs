using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Model.Common;
using LetsSuggest.Personnel.Core.Model.Personnel;
using LetsSuggest.Personnel.Core.Model.TableManagement;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace LetsSuggest.Personnel.Data.Context
{
    public class LetsSuggestContext : BaseContext<LetsSuggestContext>, ILetsSuggestContext
    {

        public LetsSuggestContext(DbContextOptions<LetsSuggestContext> options, IUserInfo userInfo)
          : base(options, userInfo)
        {
            
        }
        public DbSet<ActionButtonChild> ActionButtonChild { get; set; }
       public DbSet<PersonnelGroupMember> PersonnelGroupMember { get; set; }
        public DbSet<PersonnelGroupRight> PersonnelGroupRight { get; set; }
        public DbSet<PersonnelUserType> PersonnelUserType { get; set; }
        public DbSet<Lstactionbutton> Lstactionbutton { get; set; }
        public DbSet<Lstagency> Lstagency { get; set; }
        public DbSet<Lstbusinesscategory> Lstbusinesscategory { get; set; }
        public DbSet<Lstcategoryfilter> Lstcategoryfilter { get; set; }
        public DbSet<Lstcategorytab> Lstcategorytab { get; set; }
        public DbSet<Lstcity> Lstcity { get; set; }
        public DbSet<Lstcontact> Lstcontact { get; set; }
        public DbSet<Lstcontacttype> Lstcontacttype { get; set; }
        public DbSet<Lstcountry> Lstcountry { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Lstdocumenttype> Lstdocumenttype { get; set; }
        public DbSet<LstPersonnel> LstPersonnel { get; set; }
        public DbSet<LstFilter> Lstfilter { get; set; }
        public DbSet<Lstfiltervalue> Lstfiltervalue { get; set; }
        public DbSet<LstPersonnelGroup> LstPersonnelGroup { get; set; }
        public DbSet<LstPersonnelScreen> LstPersonnelScreen { get; set; }
        public DbSet<Lsticon> Lsticon { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Lstmemberposition> Lstmemberposition { get; set; }
        public DbSet<Lstphonetype> Lstphonetype { get; set; }
        public DbSet<Lstpincode> Lstpincode { get; set; }
        public DbSet<Lststate> Lststate { get; set; }
        public DbSet<Lsttab> Lsttab { get; set; }
        
        public DbSet<Lstusertitle> Lstusertitle { get; set; }
        
        public DbSet<LstZip> Lstzip { get; set; }
 
        
        public DbSet<PersonnelBusinessUser> PersonnelBusinessUser { get; set; }
        
        public DbSet<Review> Review { get; set; }
        
        public DbSet<LstFoodType> LstFoodType { get; set; }
        public DbSet<LstNearbyCategory> LstNearbyCategory { get; set; }
        public DbSet<AbuseReview> AbuseReview { get; set; }
        
        public DbSet<ActionCalendar> ActionCalendar { get; set; }

        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<ActionCheckIn> ActionCheckIn { get; set; }
      

        public void SetModified(object entity)
        {
            Update(entity);
        }

        public void SetAdd(object entity)
        {
            Add(entity);
        }

        public List<T> SqlQuery<T>(string query, params SqlParameter[] parameter)
        {
            var connection = Database.GetDbConnection();
            var command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            if (parameter != null)
                command.Parameters.AddRange(parameter);

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (var reader = command.ExecuteReader())
            {
                var result = DataReaderMapToList<T>(reader);
                connection.Close();
                return result;
            }
        }

        private List<T> DataReaderMapToList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            var schema = reader.GetSchemaTable();
            while (reader.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (HasColumn(schema, prop.Name) && !Equals(reader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, reader[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        private bool HasColumn(DataTable dataTable, string columnName)
        {
            dataTable.DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);
            return (dataTable.DefaultView.Count > 0);
        }

        static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)
            => category == DbLoggerCategory.Database.Command.Name
               && level == Microsoft.Extensions.Logging.LogLevel.Information, true)
        });

        static readonly MethodInfo SetGlobalQueryMethod = typeof(LetsSuggestContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                        .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.DeletedBy == null);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        

        private static IList<Type> _entityTypeCache;
        private static IList<Type> GetEntityTypes()
        {
            if (_entityTypeCache != null)
            {
                return _entityTypeCache.ToList();
            }
            _entityTypeCache = (from a in GetReferencingAssemblies()
                                from t in a.DefinedTypes
                                where t.BaseType == typeof(BaseEntity)
                                select t.AsType()).ToList();
            return _entityTypeCache;
        }
        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
                catch (FileNotFoundException)
                { /* Not handled*/ }
            }
            return assemblies;
        }
    }
}
