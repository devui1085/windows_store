using System;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class ServerDescriptor : BindableBase
    {
        public string SupportedUserClientMaxVersion { get; set; }
        public string SupportedUserClientMinVersion { get; set; }
        public string SupportedDeveloperClientMaxVersion { get; set; }
        public string SupportedDeveloperClientMinVersion { get; set; }
    }
}
