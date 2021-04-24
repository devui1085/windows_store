using System.Configuration;

namespace Store.Portal.Models
{
    public static class AppSettings
    {
        public static string PortalServiceAddress => ConfigurationManager.AppSettings.Get("PortalServiceAddress");
    }
}
