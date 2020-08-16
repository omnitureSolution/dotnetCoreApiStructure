using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Model;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;


namespace LetsSuggest.Product.Data
{
    
    public class ProductContext : BaseContext<ProductContext>, IProductContext
    {

        public ProductContext(DbContextOptions<ProductContext> options,IUserInfo userInfo)
          : base(options, userInfo)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryFeature> CategoryFeature { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<DeploymentType> DeploymentType { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Keyword> Keyword { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PopulerSearch> PopulerSearch { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductAward> ProductAward { get; set; }
        public DbSet<ProductCustomer> ProductCustomer { get; set; }
        public DbSet<ProductDeployment> ProductDeployment { get; set; }
        public DbSet<ProductDocument> ProductDocument { get; set; }
        public DbSet<ProductEnquiry> ProductEnquiry { get; set; }
        public DbSet<ProductKeyword> ProductKeyword { get; set; }
        public DbSet<ProductLink> ProductLink { get; set; }
        public DbSet<ProductPayment> ProductPayment { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<ProductSupport> ProductSupports { get; set; }
        public DbSet<ProductTraining> ProductTraining { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Support> Support { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<Business> Business { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    //modelBuilder.Configurations.Add(new DiagnosisMedicineMap());
        //}

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}
