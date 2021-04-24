using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Business.Core;
using Store.DataAccess.Context;
using Store.DomainService.Core;
using Store.StoreService.Service;
using Store.StoreService.AppCode.Common;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void IsEmailAvailable()
        {
            PersonBiz biz = new PersonBiz(new WindowsStoreContext());
            var res = biz.Where(null);
            var service = new DeveloperService();
            var userManagementDomainService = new UserManagementDomainService();
            //  var result = service.IsEmailAvailableForRegistration("ansari.va@hotmil.com");
            service.ResendActivationCode("ansari.va@hotmail.com");


            bool result = service.TryActivateAccount("ansari.va@hotmail.com", 5999);

            var r = service.GetAppCategories();
        }

        [TestMethod]
        public void SendEmail()
        {
            var mailMessage = new MailMessage("reg@paasteel.ir", "mehrta@live.com", "Activation", ServiceEmailSender.GetVerificationEmailBody("100"));
            mailMessage.SubjectEncoding = mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.zoho.com",587 );//465
            smtpClient.EnableSsl = true;
            var networkCredential = new NetworkCredential("reg@paasteel.ir", "Lenovoz510@");
            
            smtpClient.Credentials = networkCredential;
            smtpClient.Send(mailMessage);
            
            // Clean up
            mailMessage.Dispose();
        }

    }
}
