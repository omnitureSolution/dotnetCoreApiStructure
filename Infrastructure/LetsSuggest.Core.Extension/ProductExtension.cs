using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Data;
using LetsSuggest.Product.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LetsSuggest.Core.Extension
{
    public static class ProductExtension
    {
        public static void AddProductDomain(this IServiceCollection services, IConfigurationRoot configuration)
        {

            var connectionString = configuration["connectionStrings:letsSuggestContext"];
            services.AddDbContext<ProductContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IProductContext, ProductContext>();
            services.AddScoped(typeof(IUnitOfWork<>),
                typeof(UnitOfWork<>)); //, new InjectionConstructor(new GenericParameter("TContext")));
            services.AddScoped<ICategoryFeatureInterface, CategoryFeatureRepository>();
            services.AddScoped<ICategoryInterface, CategoryRepository>();
            services.AddScoped<ICityInterface, CityRepository>();
            services.AddScoped<ICountryInterface, CountryRepository>();
            services.AddScoped<IDeploymentTypeInterface, DeploymentTypeRepository>();
            services.AddScoped<IDocumentTypeInterface, DocumentTypeRepository>();
            services.AddScoped<IFeatureInterface, FeatureRepository>();
            services.AddScoped<IKeywordInterface, KeywordRepository>();
            services.AddScoped<IPaymentInterface, PaymentRepository>();
            services.AddScoped<IPopulerSearchInterface, PopulerSearchRepository>();
            services.AddScoped<IProductAwardInterface, ProductAwardRepository>();
            services.AddScoped<IProductCustomerInterface, ProductCustomerRepository>();
            services.AddScoped<IProductDeploymentInterface, ProductDeploymentRepository>();
            services.AddScoped<IProductEnquiryInterface, ProductEnquiryRepository>();
            services.AddScoped<IProductKeywordInterface, ProductKeywordRepository>();
            services.AddScoped<IProductLinkInterface, ProductLinkRepository>();
            services.AddScoped<IProductPaymentInterface, ProductPaymentRepository>();
            services.AddScoped<IProductInterface, ProductRepository>();
            services.AddScoped<IProductReviewInterface, ProductReviewRepository>();
            services.AddScoped<IProductSupportInterface, ProductSupportRepository>();
            services.AddScoped<IProductTrainingInterface, ProductTrainingRepository>();
            services.AddScoped<ISearchHistoryInterface, SearchHistoryRepository>();
            services.AddScoped<IStateInterface, StateRepository>();
            services.AddScoped<ISupportInterface, SupportRepository>();
            services.AddScoped<ITrainingInterface, TrainingRepository>();
            services.AddScoped<IUserTypeInterface, UserTypeRepository>();
            services.AddScoped<IUserInterface, UserRepository>();
            services.AddScoped<IVendorInterface, VendorRepository>();
            services.AddScoped<IBusiness, BusinessRepository>();
        }
    }
}
