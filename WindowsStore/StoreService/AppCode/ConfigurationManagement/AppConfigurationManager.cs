using System.Configuration;

namespace Store.StoreService.AppCode.ConfigurationManagement
{
    public static class AppConfigurationManager 
    {
        public static string SenderNetworkCredentialUserName => ConfigurationManager.AppSettings["SenderNetworkCredentialUserName"];
        public static string SenderNetworkCredentialPassword => ConfigurationManager.AppSettings["SenderNetworkCredentialPassword"]; 
        public static string SmtpClientHost => ConfigurationManager.AppSettings["SmtpClientHost"]; 
        public static int SmtpClientPort => int.Parse(ConfigurationManager.AppSettings["SmtpClientPort"]); 
         
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
