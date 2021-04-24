using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI;
using Windows.Storage;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class AppScreenshotPageViewModel : ViewModelBase
    {
        StoreApp _storeApp;

        public StoreApp StoreApp
        {
            get
            {
                return _storeApp;
            }

            set
            {
                _storeApp = value;
                RaisePropertyChanged();
            }
        }
        public int ScreenshotIndex { get; set; }
        public ObservableCollection<Screenshot> Screenshots { get; set; }

        public AppScreenshotPageViewModel()
        {
            Screenshots = new ObservableCollection<Screenshot>();
        }

        public async Task LoadScreenshotsAsync()
        {
            var loadOrder = Enumerable.Range(0, StoreApp.NumberOfMobileScreenshots).ToList();
            loadOrder.Remove(ScreenshotIndex);
            loadOrder.Insert(0, ScreenshotIndex);

            foreach (var index in loadOrder) {
                try {
                    var appScreenshot = await AppManager.Instance.GetAppScreenShotAsync(
                        StoreApp.Guid,
                        AppScreenshotType.Mobile,
                        AppScreenshotSize.Original,
                        index);
                    Screenshots.Add(appScreenshot);
                }
                catch {

                }
            }
        }
    }
}
