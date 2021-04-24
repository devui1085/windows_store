using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.Developer.Logic;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.Services;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.AppModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppScreenshotsPage : Page
    {
        private IAlertMessageService _alertMessageService;
        private IResourceLoader _resourceLoader;

        public AppScreenshotsPage()
        {
            this.InitializeComponent();

            _alertMessageService = ((IAppScreenshotsPageViewModel) DataContext).GetAlertMessageService();
            _resourceLoader = ((IAppScreenshotsPageViewModel) DataContext).GetResourceLoader();

        }

        private const long MaxMobileScreenshotSizeUnit = 300;
        private const long MaxMobileScreenshotSize= MaxMobileScreenshotSizeUnit * 1024; // 300 KB
        private async void SendMobileScreenshot_Click(object sender, RoutedEventArgs e)
        {
            var appScreenshotPageViewModel = (IAppScreenshotsPageViewModel)this.DataContext;

            var open = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };
            // Filter to include a sample subset of file types
            open.FileTypeFilter.Clear();
            open.FileTypeFilter.Add(".png");
            open.FileTypeFilter.Add(".jpg");
            open.FileTypeFilter.Add(".jpeg");

            var file = await open.PickSingleFileAsync();
            if (file == null) return;

            var fileProperties = await file.GetBasicPropertiesAsync();
            if (fileProperties.Size > MaxMobileScreenshotSize)
            {
                await
                    _alertMessageService.ShowAsync(
                        string.Format(_resourceLoader.GetString("MobileScreenshotSizeExceedsTheAllowableLimit"),
                            MaxMobileScreenshotSizeUnit), null, DialogCommands.CloseDialogCommand);
                return;
            }

            //var x = await fileProperties.RetrievePropertiesAsync(new string[] {"Height", "Width"});


            using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(fileStream);

                // load original image
                var sourceBitmapImage = new BitmapImage{ DecodePixelType= DecodePixelType.Physical};
                fileStream.Seek(0);
                await sourceBitmapImage.SetSourceAsync(fileStream);

                var sourceImageHeight = sourceBitmapImage.PixelHeight;
                var originalWidth = sourceBitmapImage.PixelWidth;

                // create thubmnail image
                const int thumbnailHeight = 400;
                var thumbnailWidth = thumbnailHeight * originalWidth / sourceImageHeight;

                var thumbnailBitmapImage = new BitmapImage
                {
                    DecodePixelHeight = thumbnailHeight,
                    DecodePixelWidth = thumbnailWidth ,
                    DecodePixelType = DecodePixelType.Physical
                };

                fileStream.Seek(0);
                await thumbnailBitmapImage.SetSourceAsync(fileStream);
                

                var screenshot = new AppScreenshot();

                var appSpecification = appScreenshotPageViewModel.AppDetail.AppSpecification;
                screenshot.AppGuid = appSpecification.Guid;
                screenshot.AppId = appSpecification.AppId;
                screenshot.FileName = Guid.NewGuid() + Path.GetExtension(file.Name);
                screenshot.Thumbnail = thumbnailBitmapImage;
                screenshot.SourceImageStorageFile = file;
                screenshot.ScreenshotSize = Logic.DeveloperService.ScreenshotSize.Original;
                screenshot.ScreenshotType = Logic.DeveloperService.ScreenshotType.Mobile;
           
                appScreenshotPageViewModel.AddScreenshot(screenshot);

            }
        }
    }
}
