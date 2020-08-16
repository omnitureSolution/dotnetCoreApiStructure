using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Data.Context;
using LetsSuggest.Personnel.Data.Repository.Common;
using LetsSuggest.Personnel.Data.Repository.Personnel;
using LetsSuggest.Personnel.Data.Repository.TableManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsSuggest.Core.Extension
{
    public static class LetsSuggestExtension
    {
        public static void AddDomain(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<LetsSuggestContext>(o =>
            {
                var connectionString = configuration["ConnectionStrings:LetsSuggestContext"];
                o.UseSqlServer(connectionString);
                o.EnableSensitiveDataLogging();
            });

            services.AddScoped<ILetsSuggestContext, LetsSuggestContext>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<ILstPersonnelInterface, PersonnelRepository>();
           
            services.AddScoped<IStateInterface, StateRepository>();
            services.AddScoped<ICityInterface, CityRepository>();
            services.AddScoped<IPinCodeInterface, PincodeRepository>();
     

            services.AddScoped<IPersonnelGroupMemberInterface, PersonnelGroupMemberRepository>();
            services.AddScoped<ILstPersonnelGroupInterface, PersonnelGroupRepository>();
            services.AddScoped<IPersonnelGroupRightInterface, PersonnelGroupRightRepository>();
            services.AddScoped<ILstPersonnelScreenInterface, PersonnelScreenRepository>();
            
            services.AddScoped<IGalleryInterface, GalleryRepository>();
            services.AddScoped<ILocationInterface, LocationRepository>();
            services.AddScoped<ICountryInterface, CountryRepository>();
        }
    }
}
