using BaseDataLayer;
using Jainism.Context;
using Jainism.Core.Interfaces;
using Jainism.Data.Repository;
using Jainism.Data.Repository.Personnel;
using Jainism.Data.Repository.PoojaDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jainism.Data
{
    public static class JainismUowExtension
    {
        public static void AddJainismDomain(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<JainismContext>(o =>
            {
                var connectionString = configuration["ConnectionStrings:JainismContext"];
                o.UseSqlServer(connectionString);
                o.EnableSensitiveDataLogging();
            });

            services.AddScoped<IJainismContext, JainismContext>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<ILstPersonnelInterface, PersonnelRepository>();
            services.AddScoped<IPhoneTypeInterface, PhoneTypeRepository>();
            services.AddScoped<IActionButtonInterface, ActionButtonRepository>();
            services.AddScoped<IFilterInterface, FilterRepository>();
            services.AddScoped<ITabsInterface, TabsRepository>();
            services.AddScoped<IBusinessCategoryInterface, BusinessCategoryRepository>();
            services.AddScoped<IEventInterface, EventsRepository>();
            services.AddScoped<IBusinessInterface, BusinessRepository>();
            services.AddScoped<IBusinessBookInterface, BusinessBookRepository>();
            services.AddScoped<IBussSpecializationInterface, BussSpecializationRepository>();
            services.AddScoped<ILstCategorySetupInterface, CategorySetupRepository>();
            services.AddScoped<ILstCategoryFilterSetupInterface, CategoryFilterSetupRepository>();
            services.AddScoped<ILocationInterface, LocationRepository>();
            services.AddScoped<IUserTitleInterface, UserTitleRepository>();
            services.AddScoped<IContactTypeInterface, ContactTypeRepository>();
            services.AddScoped<IMemberPositionInterface, MemberPositionRepository>();
            services.AddScoped<ICountryInterface, CountryRepository>();
            services.AddScoped<IStateInterface, StateRepository>();
            services.AddScoped<ICityInterface, CityRepository>();
            services.AddScoped<IPinCodeInterface, PincodeRepository>();
            services.AddScoped<INetworkLogInterface, NetWorkLogRepository>();
            services.AddScoped<IBusinessContactsInterface, BusinessContactsRepository>();
            services.AddScoped<IBusinessOwnerInterface, BusinessOwnerRepository>();
            services.AddScoped<IBusinessHoursOfOperationInterface, BusinessHoursOfOperationRepository>();
            services.AddScoped<IBusinessHoursCloseInterface, BusinessHoursCloseRepository>();

            services.AddScoped<IPersonnelGroupMemberInterface, PersonnelGroupMemberRepository>();
            services.AddScoped<ILstPersonnelGroupInterface, PersonnelGroupRepository>();
            services.AddScoped<IPersonnelGroupRightInterface, PersonnelGroupRightRepository>();
            services.AddScoped<ILstPersonnelScreenInterface, LstPersonnelScreenRepository>();


            services.AddScoped<IPanchangInterface, PanchangRepository>();
            services.AddScoped<IFielddictionaryInterface, FielddictionaryRepository>();
            services.AddScoped<IBusinessCommitteInterface, BusinessCommitteRepository>();
            services.AddScoped<IBusinessMembersInterface, BusinessMembersRepository>();
            services.AddScoped<IBusinessTrustInterface, BusinessTrustRepository>();
            services.AddScoped<IBusinessnarrativeInterface, BusinessnarrativeRepository>();
            services.AddScoped<IBusinessDescFacilitiesInterface, BusinessDescFacilitiesRepository>();
            services.AddScoped<IBusinessDescIdolsInterface, BusinessDescIdolsRepository>();
            services.AddScoped<IContactRequestInterface, ContactRequestRepository>();
            services.AddScoped<IReviewInterface, ReviewRepository>();
            services.AddScoped<IFilterValueInterface, FilterValueRepository>();

            services.AddScoped<ICommonInterface, CommonRepository>();

            services.AddScoped<IServiceInterface, ServiceRepository>();
            services.AddScoped<IPoojaInterface, PoojaRepository>();
            services.AddScoped<IPoojaSchemeInterface, PoojaSchemeRepository>();

            //services.AddScoped<IPoojaPriceHistoryInterface, PoojaPriceHistoryRepository>();
            services.AddScoped<IAboutUsInterface, AboutUsRepository>();
            services.AddScoped<IBookMarkInterface, BookMarkRepository>();
            services.AddScoped<IOtpVerificationInterface, OtpVerificationRepository>();
            services.AddScoped<IBusinessMenuInterface, BusinessMenuRepository>();
            services.AddScoped<IDocumentDataInterface, DocumentDataRepository>();

            services.AddScoped<INearByCategoryInterface, NearByCategoryRepository>();
            services.AddScoped<IAbuseReviewInterface, AbuseReviewRepository>();

            services.AddScoped<IlstFoodTypeInterface, FoodTypeRepository>();
            services.AddScoped<IImageDataInterface, ImageDataRepository>();
            services.AddScoped<IDocumentDataInterface, DocumentDataRepository>();
        }
    }
}
