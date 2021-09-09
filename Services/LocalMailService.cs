using System.Diagnostics;
namespace api.Services
{
    public class LocalMailService
    {
        private string _mailTo = "admin@company.com";

        private string _mailFrom = "noreply@company.com";

        public void Send(string subject, string message)
        {
            Debug.Write($"Email send {_mailFrom} and {_mailTo}");
            Debug.Write($"Subject: {subject}");
            Debug.Write($"Message: {message}");
        }

    }
}
