using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UI;
using Windows.ApplicationModel.Activation;
using Windows.Networking.BackgroundTransfer;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Local.PackageManagement;
using WindowsStore.Client.User.UI.Infrastructure.Timer;

namespace WindowsStore.Client.User.UI.Startup
{
    public static class StartupManager
    {
        internal static void HandleStartupEvent(LaunchActivatedEventArgs e)
        {
            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated) {
                //TODO: Load state from previously suspended application
            }

            AppInitializer.InitializeAppModules();
        }

        internal static void HandleResumeEvent()
        {

        }
    }
}
