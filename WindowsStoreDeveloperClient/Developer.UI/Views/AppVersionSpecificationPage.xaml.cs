using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web;
using WindowsStore.Client.Developer.Logic;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.AppModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppVersionSpecificationPage : Page
    {
        //private const string ServerAddress = "http://localhost/AppCode/HttpHandler/AppUpload.ashx";
        private CancellationTokenSource _cts;
        private IAppVersionSpecificationPageViewModel _dataContext;

        private const int MaxUploadFileSizeUnit = 300; // 300 MB (arbitrary limit chosen for this sample)
        private const int MaxUploadFileSize = MaxUploadFileSizeUnit*1024*1024;

        private readonly IAlertMessageService _alertMessageService;
        private IResourceLoader _resourceLoader;


        public AppVersionSpecificationPage()
        {
            this.InitializeComponent();
            _alertMessageService = null;
            _cts = new CancellationTokenSource();

            _alertMessageService = ((IAppVersionSpecificationPageViewModel) DataContext).GetAlertMessageService();
            _resourceLoader = ((IAppVersionSpecificationPageViewModel) DataContext).GetResourceLoader();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _dataContext = (IAppVersionSpecificationPageViewModel) this.DataContext;
        }

        private StorageFile _armPackageStorageFile;
        private StorageFile _x86PackageStorageFile;
        private StorageFile _x64PackageStorageFile;


        private void SelectX64PackageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SelectPackage(CpuArchitecture.X64);
        }

        private void SelectX86PackageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SelectPackage(CpuArchitecture.X86);
        }

        private void SelectArmPackageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SelectPackage(CpuArchitecture.Arm);
        }

        private void SelectPackage(CpuArchitecture fileType)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".appx");

#if WINDOWS_PHONE_APP
            picker.ContinuationData.Add("uri", uri.OriginalString);
            picker.PickSingleFileAndContinue();
#else
            LoadSingleFile(picker, fileType);
#endif
        }


        private async void LoadSingleFile(FileOpenPicker picker, CpuArchitecture fileType)
        {
            try
            {
                var selectedFile = await picker.PickSingleFileAsync();

                var properties = await selectedFile.GetBasicPropertiesAsync();
                if (properties.Size > MaxUploadFileSize)
                {
                    await
                        _alertMessageService.ShowAsync(
                            String.Format(CultureInfo.CurrentCulture,
                                _resourceLoader.GetString("FileExceedsTheMaximumFileSize"), MaxUploadFileSizeUnit), null,
                            DialogCommands.CloseDialogCommand);
                    return;
                }

                switch (fileType)
                {
                    case CpuArchitecture.Arm:
                        _armPackageStorageFile = selectedFile;
                        _dataContext.AppVersion.ArmPackageSize = (long) properties.Size;
                        break;
                    case CpuArchitecture.X64:
                        _x64PackageStorageFile = selectedFile;
                        _dataContext.AppVersion.X64PackageSize = (long) properties.Size;
                        break;
                    case CpuArchitecture.X86:
                        _x86PackageStorageFile = selectedFile;
                        _dataContext.AppVersion.X86PackageSize = (long) properties.Size;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                
            }
            //  UploadSingleFile(file);
        }


        private ProgressBar _currentProgressBar;


        private async void SendPackagesButton_Click(object sender, RoutedEventArgs e)
        {
            bool updateCurrentVersion = false;
            try
            {
                // check if page is on update state only update current version
                if (!AllPackagesIsSelected(false) && _dataContext.PageIsOnUpdateState())
                {
                    updateCurrentVersion = true;
                    goto UpdateVersion;
                }

                if (AllPackagesIsSelected(true) && _dataContext.NewVersionIsEqualOrLessThanCurrentVersion())
                {
                   await _alertMessageService.ShowAsync(_resourceLoader.GetString("NewVersionIsEqualOrLessThanCurrentVersion"), null, DialogCommands.CloseDialogCommand);
                   return;
                }

                if (!_dataContext.VersionFormIsValid() || !AllPackagesIsSelected(true)) return;

                // start upload packages
                SendPackagesButton.Visibility = Visibility.Collapsed;
                CancelSendingPackagesButton.Visibility = Visibility.Visible;

                if (_dataContext.IsArmPackageMandatory && _armPackageStorageFile != null)
                {
                    _currentProgressBar = ArmProgressBar;
                    await UploadSingleFile(_armPackageStorageFile, CpuArchitecture.Arm);
                    _dataContext.AppVersion.HasArmPackage = true;
                }

                if (_dataContext.IsX64PackageMandatory && _x64PackageStorageFile != null)
                {
                    _currentProgressBar = X64ProgressBar;
                    await UploadSingleFile(_x64PackageStorageFile, CpuArchitecture.X64);
                    _dataContext.AppVersion.HasX64Package = true;
                }

                if (_dataContext.IsX86PackageMandatory && _x86PackageStorageFile != null)
                {
                    _currentProgressBar = X86ProgressBar;
                    await UploadSingleFile(_x86PackageStorageFile, CpuArchitecture.X86);
                    _dataContext.AppVersion.HasX86Package = true;
                }


                UpdateVersion:
                // save version
                _dataContext.SaveAppVersionSpecificationAsync(updateCurrentVersion);

            }
            catch (TaskCanceledException)
            {
                SendPackagesButton.Visibility = Visibility.Visible;
                CancelSendingPackagesButton.Visibility = Visibility.Collapsed;
            }
            catch
            {
                await _alertMessageService.ShowAsync(_resourceLoader.GetString("ErrorOnUploadingPackages"), null, DialogCommands.CloseDialogCommand);

                SendPackagesButton.Visibility = Visibility.Visible;
                CancelSendingPackagesButton.Visibility = Visibility.Collapsed;
            }
        }

        private async void CancelSendingPackagesButton_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
            _cts.Dispose();

            // Re-create the CancellationTokenSource and activeUploads for future uploads.
            _cts = new CancellationTokenSource();
        }
        private bool AllPackagesIsSelected(bool showMessage)
        {
            if (_dataContext.IsArmPackageMandatory && _armPackageStorageFile == null)
            {
                if (showMessage)
                    _alertMessageService.ShowAsync(_resourceLoader.GetString("PackageArmNotSelected"), null, DialogCommands.CloseDialogCommand);
                return false;
            }

            if (_dataContext.IsX86PackageMandatory && _x86PackageStorageFile == null)
            {
                if (showMessage)
                    _alertMessageService.ShowAsync(_resourceLoader.GetString("PackageX86NotSelected"), null, DialogCommands.CloseDialogCommand);
                return false;
            }

            if (_dataContext.IsX64PackageMandatory && _x64PackageStorageFile == null)
            {
                if (showMessage)
                    _alertMessageService.ShowAsync(_resourceLoader.GetString("PackageX64NotSelected"), null, DialogCommands.CloseDialogCommand);
                return false;
            }

            return true;
        }

        private async Task UploadSingleFile(StorageFile file, CpuArchitecture fileType)
        {
            var uri = new Uri(Constants.PackageUploadServerUrl);

            var uploader = new BackgroundUploader();
            uploader.SetRequestHeader("Filename", file.Name);
            uploader.SetRequestHeader("Guid", _dataContext.AppDetail.AppSpecification.Guid.ToString());
            uploader.SetRequestHeader("AppName", fileType.ToString());
      

            var upload = uploader.CreateUpload(uri, file);
            //Log(String.Format(CultureInfo.CurrentCulture, "Uploading {0} to {1}, {2}", file.Name, uri.AbsoluteUri,
            //    upload.Guid));

            // Attach progress and completion handlers.
            await HandleUploadAsync(upload, true);
        }

        private async Task HandleUploadAsync(UploadOperation upload, bool start)
        {
                var progressCallback = new Progress<UploadOperation>(UploadProgress);
                if (start)
                {
                    // Start the upload and attach a progress handler.
                    await upload.StartAsync().AsTask(_cts.Token, progressCallback);
                }
                else
                {
                    // The upload was already running when the application started, re-attach the progress handler.
                    await upload.AttachAsync().AsTask(_cts.Token, progressCallback);
                }

                var response = upload.GetResponseInformation();
        }

        private bool IsExceptionHandled(string title, Exception ex, UploadOperation upload = null)
        {
            var error = BackgroundTransferError.GetStatus(ex.HResult);
            return error != WebErrorStatus.Unknown;
        }

        // Note that this event is invoked on a background thread, so we cannot access the UI directly.
        private void UploadProgress(UploadOperation upload)
        {
            var progress = upload.Progress;

            double percentSent = 100;
            if (progress.TotalBytesToSend > 0)
            {
                percentSent = progress.BytesSent * 100 / progress.TotalBytesToSend;
            }

            _currentProgressBar.Value = percentSent;

            if (progress.HasResponseChanged)
            {
                // If you want to stream the response data this is a good time to start.
                // upload.GetResultStreamAt(0);
            }
        }

        protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            var currentUploads =await BackgroundUploader.GetCurrentUploadsAsync();

            if (currentUploads.Count > 0)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
        }

    }
}
