using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Text;

namespace Store.Common.Messaging
{
    /// <summary>
    /// Helper class for send email using current smtpServer
    /// </summary>
    public class EmailService
    {
        #region innter types

        /// <summary>
        /// Email Sender
        /// </summary>
        public class Sender
        {
            public string NetworkCredentialUserName { get; set; }
            public string NetworkCredentialPassword { get; set; }
            public string DisplayName { get; set; }
        }

        class SmtpServer
        {
            public string Host { get; set; }
            public int Port { get; set; }
        }

        #endregion

        //static Sender sender;
        readonly SmtpServer _smtpServer = new SmtpServer();

        public EmailService()
        {
            // initial smtp server
            _smtpServer.Host = ConfigurationManager.AppSettings["SmtpClientHost"];
            _smtpServer.Port = int.Parse(ConfigurationManager.AppSettings["SmtpClientPort"]);
        }

        public EmailService(string smtpClientHost, int smtpClientPort)
        {
            // initial smtp server
            _smtpServer.Host = smtpClientHost;
            _smtpServer.Port = smtpClientPort;
        }

        public void SendMail(Sender sender, string to, string subject, string body)
        {
            var mailMessage = new MailMessage(sender.NetworkCredentialUserName, to, subject, body);
            mailMessage.SubjectEncoding = mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient(_smtpServer.Host, _smtpServer.Port);
            var networkCredential = new NetworkCredential(sender.NetworkCredentialUserName, sender.NetworkCredentialPassword);
            smtpClient.EnableSsl = true;
            
            smtpClient.Credentials = networkCredential;
            smtpClient.Send(mailMessage);

            // Clean up
            mailMessage.Dispose();
        }

        public void SendMail(Sender sender, HashSet<string> to, string subject, string body)
        {
            SendMail(sender, string.Join(",", to), subject, body);
        }
    }
}