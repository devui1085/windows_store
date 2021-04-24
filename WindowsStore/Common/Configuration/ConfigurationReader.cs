using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common.Configuration
{
    public static class ConfigurationReader
    {
        public static string AppsDirectoryPath => ConfigurationManager.AppSettings["AppsDirectoryPath"];
        public static string SupportedUserClientMinVersion => ConfigurationManager.AppSettings["SupportedUserClientMinVersion"];
        public static string SupportedUserClientMaxVersion => ConfigurationManager.AppSettings["SupportedUserClientMaxVersion"];
        public static string SupportedDeveloperClientMinVersion => ConfigurationManager.AppSettings["SupportedDeveloperClientMinVersion"];
        public static string SupportedDeveloperClientMaxVersion => ConfigurationManager.AppSettings["SupportedDeveloperClientMaxVersion"];
    }
}
