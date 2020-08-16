using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsSuggest.Shared.Helper
{
    public static class LogSettingsMapping
    {
        public static void AddlogSettingConfig(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<LoginSetting>(configuration.GetSection("LoginSetting"));
            services.Configure<MessageTemplate>(configuration.GetSection("MessageTemplate"));
        }
    }
    public class LoginSetting
    {
        public int MaxAttempt { get; set; }
        public int OTPExpire { get; set; }
    }
    public class MessageTemplate
    {
        public string WebUrl { get; set; }
        public string LogoPath { get; set; }
        public string Copyright { get; set; }
        public string Address { get; set; }
        public string MailFrom { get; set; }
        public string MailPort { get; set; }
        public string MailPassword { get; set; }
        public string MailSenderName { get; set; }
        public bool MailSsl { get; set; }

    }
}
