using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Remote.Wcf;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public static class SettingManager
    {
        static SettingManager()
        {

        }

        public static bool AutomaticallyUpdateCurrentApp
        {
            get
            {
                var value = LocalSettings.Get(LocalSettingKeys.AutomaticUpdate);
                if (value != null)
                {
                    return (bool)value;
                }
                return true;
            }

            set
            {
                LocalSettings.Set(LocalSettingKeys.AutomaticUpdate, value);
            }
        }

    }
}
