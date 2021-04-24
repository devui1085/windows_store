using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppIconPage : Page
    {
        public AppIconPage()
        {
            this.InitializeComponent();
        }

        private async void ChooseIcon256X256Button_Click(object sender, RoutedEventArgs e)
        {
            var appIconPageViewModel = (IAppIconPageViewModel)this.DataContext;

            var open = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };
            // Filter to include a sample subset of file types
            open.FileTypeFilter.Clear();
            open.FileTypeFilter.Add(".png");

            var file = await open.PickSingleFileAsync();
            if (file == null) return;
            using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(fileStream);

                if (bitmapImage.PixelHeight != 256 || bitmapImage.PixelWidth != 256)
                {
                    appIconPageViewModel.ShowImageSizeError();
                    return;
                }

                //continue
                //var bitmapImage128X128 = new BitmapImage
                //{
                //    DecodePixelHeight = 128,
                //    DecodePixelWidth = 128,
                //    DecodePixelType = DecodePixelType.Physical
                //};

                //fileStream.Seek(0);
                //await bitmapImage128X128.SetSourceAsync(fileStream);
              
                var bitmapImage256X256 = new BitmapImage
                {
                    DecodePixelHeight = 256,
                    DecodePixelWidth = 256,
                    DecodePixelType = DecodePixelType.Physical
                };

                fileStream.Seek(0);
                await bitmapImage256X256.SetSourceAsync(fileStream);

                // set  viewmodel properties
                //appIconPageViewModel.AppDetail.AppIcon.Icon128X128 = bitmapImage128X128;
                appIconPageViewModel.AppDetail.AppIcon.Icon256X256 = bitmapImage256X256;
                appIconPageViewModel.AppDetail.AppIcon.Icon256X256StorageFile = file;

                // show image on page
                IconImage.Source = bitmapImage256X256;
                SaveButton.IsEnabled = true;
            }
        }
    }
}
