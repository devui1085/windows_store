using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class SettingsPageViewModel : ViewModelBase
    {

        public bool AutomaticUpdate
        {
            get
            {
                return SettingManager.AutomaticallyUpdateCurrentApp;
            }
            set
            {
                SettingManager.AutomaticallyUpdateCurrentApp = value;
            }
        }

        public SettingsPageViewModel()
        {
            UiManager.PageTitle = "Settings".Localize();
        }

    }
}
