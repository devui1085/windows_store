using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.Service.Local.PackageManagement
{
    public class PackageInstallationResult
    {
        public long Code { get; set; }
        public string CodeText { get; set; }
        public string Reason { get; set; }
        public bool Success { get; set; }

        public static PackageInstallationResult ConnectToDevicePortalFailed
        {
            get
            {
                return new PackageInstallationResult()
                {
                    Code = long.MinValue,
                    CodeText = "Connecting to the device portal failed.",
                    Reason = "",
                    Success = false
                };
            }
        }
    }
}
