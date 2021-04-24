using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Store.Common.Messaging;
using Store.StoreService.AppCode.ConfigurationManagement;
using System.Configuration;
using Store.StoreService.Properties;
using System.Threading.Tasks;

namespace Store.StoreService.AppCode.Common
{
    public static class ServiceEmailSender
    {
        public static Task SendVerificationEmailAsync(string email, string verficationCode)
        {
            var emailService = new EmailService(AppConfigurationManager.SmtpClientHost, AppConfigurationManager.SmtpClientPort);
            var sender = new EmailService.Sender
            {
                NetworkCredentialUserName = AppConfigurationManager.SenderNetworkCredentialUserName,
                NetworkCredentialPassword = AppConfigurationManager.SenderNetworkCredentialPassword
            };

            return Task.Factory.StartNew(() =>
            {
                emailService.SendMail(sender, email, Resources.ActivationCode, GetVerificationEmailBody(verficationCode));
            });
        }

        public static string GetVerificationEmailBody(string verificationCode)
        {
            var mailText = Properties.Resources.ActivationEmail;
            return mailText.Replace("@VerificationCode@", verificationCode);
        }
    }
}