using LetsSuggest.Context;
using LetsSuggest.Product.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace LetsSuggest.Product.Core
{
    public interface IProductContext : IContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<CategoryFeature> CategoryFeature { get; set; }
        DbSet<City> City { get; set; }
        DbSet<Country> Country { get; set; }
        DbSet<DeploymentType> DeploymentType { get; set; }
        DbSet<DocumentType> DocumentType { get; set; }
        DbSet<Feature> Feature { get; set; }
        DbSet<Keyword> Keyword { get; set; }
        DbSet<Payment> Payment { get; set; }
        DbSet<PopulerSearch> PopulerSearch { get; set; }
        DbSet<ProductDetails> ProductDetails { get; set; }
        DbSet<ProductAward> ProductAward { get; set; }
        DbSet<ProductCustomer> ProductCustomer { get; set; }
        DbSet<ProductDeployment> ProductDeployment { get; set; }
        DbSet<ProductDocument> ProductDocument { get; set; }
        DbSet<ProductEnquiry> ProductEnquiry { get; set; }
        DbSet<ProductKeyword> ProductKeyword { get; set; }
        DbSet<ProductLink> ProductLink { get; set; }
        DbSet<ProductPayment> ProductPayment { get; set; }
        DbSet<ProductReview> ProductReview { get; set; }
        DbSet<ProductSupport> ProductSupports { get; set; }
        DbSet<ProductTraining> ProductTraining { get; set; }
        DbSet<SearchHistory> SearchHistory { get; set; }
        DbSet<State> State { get; set; }
        DbSet<Support> Support { get; set; }
        DbSet<Training> Training { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserType> UserType { get; set; }
        DbSet<Vendor> Vendor { get; set; }
        DbSet<Business> Business { get; set; }
    }
}
