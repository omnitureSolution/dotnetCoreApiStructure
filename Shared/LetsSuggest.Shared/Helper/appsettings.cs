using System;
using LetsSuggest.Shared.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsSuggest.Shared.Helper
{
    public static class ConfigurationMapping
    {
        public static void AddConfig(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AuthenticationKeys>(configuration.GetSection("AuthenticationKeys"));
            services.Configure<Logging>(configuration.GetSection("Logging"));
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
            services.Configure<ImagePath>(configuration.GetSection("ImagePath"));
            services.Configure<LoginSetting>(configuration.GetSection("LoginSetting"));
            services.Configure<MessageTemplate>(configuration.GetSection("MessageTemplate"));

            services.AddScoped<IEmailService, EmailService>();
        }
    }

    public class Logging
    {
        public Boolean IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public String Default { get; set; }
        public String System { get; set; }
        public String Microsoft { get; set; }

    }

    public class ConnectionStrings
    {
        public string letssuggestDB { get; set; }
    }

    public class ApplicationSettings
    {
        public string Mode { get; set; }
    }

    public class ImagePath
    {
        public string ImageDir { get; set; }
        public string OriginalDir { get; set; }
        public string ThumbnailDir { get; set; }
    }

    public class DocPath
    {
        public string DocDir { get; set; }
        public string SavedDoc { get; set; }
    }

    public class FtpSetting
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationKeys
    {
        public String Issuer { get; set; }
        public String Audience { get; set; }
        public String SigningKey { get; set; }
    }

}
