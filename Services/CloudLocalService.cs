using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public class CloudLocalService : IMailService
    {
        private IConfiguration _configuration;
        public CloudLocalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string subject, string message)
        {
            Debug.Write($"Email send {_configuration["mailSettings:mailToAdsress"]} and {_configuration["mailSettings:mailFromAddress"]} LocalMailService");
            Debug.Write($"Subject: {subject}");
            Debug.Write($"Message: {message}");
        }
    }
}
