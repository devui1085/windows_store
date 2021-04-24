using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.System;
using WindowsStore.Client.User.Common.Enum;

namespace WindowsStore.Client.User.Service.Local
{
    public static class DeviceInfo
    {
        public static ProcessorArchitecture GetProcessorArchitecture()
        {
            if (Package.Current.Id.Architecture == ProcessorArchitecture.Arm)
                return ProcessorArchitecture.Arm;
            return Marshal.SizeOf<IntPtr>() == 8 ? ProcessorArchitecture.X64 : ProcessorArchitecture.X86;
        }
    }
}
