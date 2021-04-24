using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.System;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;

namespace WindowsStore.Client.User.Service.Local
{
    public static class CurrentApplication
    {
        public static Version Version
        {
            get
            {
                var v = Package.Current.Id.Version;
                return new Version(v.Major, v.Minor, v.Build, v.Revision);
            }
        }

        public static StorageFolder AppDownloadFolder
        {
            get
            {
                return ApplicationData.Current.TemporaryFolder;
            }
        }

        public static Guid Guid
        {
            get
            {
                return Guid.Empty;
            }
        }

        public static string Name
        {
            get
            {
                return "Paasteel".Localize();
            }
        }
    }
}
