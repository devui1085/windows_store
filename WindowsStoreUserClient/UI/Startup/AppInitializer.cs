using WindowsStore.Client.User.Service.ApplicationService.Initilize;
using WindowsStore.Client.User.UI.Infrastructure.Timer;

namespace WindowsStore.Client.User.UI.Startup
{
    public static class AppInitializer
    {
        static AppInitializer()
        {
        }

        public static void InitializeAppModules()
        {
            InitializeDeviceRegistrationService();
            InitializeUpdateService();
            InitializeDownloadManager();
            InitializeAutoSignIn();
        }

        private static void InitializeDeviceRegistrationService()
        {
            var timer = new CountdownTimer(100);
            timer.Action = param => { DeviceRegistrationServiceInitializer.Initialize(); };
            timer.Start();
        }

        private static void InitializeUpdateService()
        {

            var timer = new CountdownTimer(500);
            timer.Action = param => { UpdateServiceInitializer.Initialize(); };
            timer.Start();
        }

        private static void InitializeDownloadManager()
        {

            var timer = new CountdownTimer(2000);
            timer.Action = param => { DownloadManagerInitializer.Initialize(); };
            timer.Start();
        }

        private static void InitializeAutoSignIn()
        {
            var timer = new CountdownTimer(3000);
            timer.Action = param => { SignInInitializer.Initialize(); };
            timer.Start();
        }
    }
}
