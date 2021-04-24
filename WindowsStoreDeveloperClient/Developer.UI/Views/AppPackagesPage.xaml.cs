using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.Web;
using WindowsStore.Client.Developer.Logic.ServiceInterface;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppPackagesPage : Page
    {
        private IAlertMessageService _alertMessageService;
        private const string serverAddress = "http://localhost/AppCode/HttpHandler/AppUpload.ashx";
        private CancellationTokenSource cts;

        private const int maxUploadFileSize = 300 * 1024 * 1024; // 100 MB (arbitrary limit chosen for this sample)

        public AppPackagesPage()
        {
            this.InitializeComponent();
            _alertMessageService = null;
            cts = new CancellationTokenSource();
        }

        private void SelectX64PackageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            StartUpload("X64");
        }

        private void SelectX86PackageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            StartUpload("X32");
        }

        private void SelectArmPackageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            StartUpload("ARM");
        }

        private void StartUpload(string token)
        {
            Uri uri = new Uri(serverAddress);

            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add("*");

            #if WINDOWS_PHONE_APP
            picker.ContinuationData.Add("uri", uri.OriginalString);
            picker.PickSingleFileAndContinue();
            #else
            StartSingleFileUpload(picker, uri);
            #endif
        }

        private async void StartSingleFileUpload(FileOpenPicker picker, Uri uri)
        {
            StorageFile file = await picker.PickSingleFileAsync();
            UploadSingleFile(uri, file);
        }

        private async void UploadSingleFile(Uri uri, StorageFile file)
        {
            if (file == null)
            {
              //  rootPage.NotifyUser("No file selected.", NotifyType.ErrorMessage);
                return;
            }

            var properties = await file.GetBasicPropertiesAsync();
            if (properties.Size > maxUploadFileSize)
            {
                await _alertMessageService.ShowAsync(String.Format(CultureInfo.CurrentCulture,
                    "Selected file exceeds max. upload file size ({0} MB).", maxUploadFileSize/(1024*1024)),
                    null);
                return;
            }

            var uploader = new BackgroundUploader();
            uploader.SetRequestHeader("Filename", file.Name);
            uploader.SetRequestHeader("AppId", "15");
            uploader.SetRequestHeader("Guid", "1");
            uploader.SetRequestHeader("AppName","Arm");


            UploadOperation upload = uploader.CreateUpload(uri, file);
            //Log(String.Format(CultureInfo.CurrentCulture, "Uploading {0} to {1}, {2}", file.Name, uri.AbsoluteUri,
            //    upload.Guid));

            // Attach progress and completion handlers.
            await HandleUploadAsync(upload, true);
        }

        private async Task HandleUploadAsync(UploadOperation upload, bool start)
        {
            try
            {
                //LogStatus("Running: " + upload.Guid, NotifyType.StatusMessage);

                var progressCallback = new Progress<UploadOperation>(UploadProgress);
                if (start)
                {
                    // Start the upload and attach a progress handler.
                    await upload.StartAsync().AsTask(cts.Token, progressCallback);
                }
                else
                {
                    // The upload was already running when the application started, re-attach the progress handler.
                    await upload.AttachAsync().AsTask(cts.Token, progressCallback);
                }

                ResponseInformation response = upload.GetResponseInformation();

                //LogStatus(String.Format(CultureInfo.CurrentCulture, "Completed: {0}, Status Code: {1}", upload.Guid,
                //    response.StatusCode), NotifyType.StatusMessage);
            }
            catch (TaskCanceledException)
            {
                //LogStatus("Canceled: " + upload.Guid, NotifyType.StatusMessage);
            }
            catch (Exception ex)
            {
                if (!IsExceptionHandled("Error", ex, upload))
                {
                    throw;
                }
            }
        }

        private bool IsExceptionHandled(string title, Exception ex, UploadOperation upload = null)
        {
            var error = BackgroundTransferError.GetStatus(ex.HResult);
            if (error == WebErrorStatus.Unknown)
            {
                return false;
            }

            if (upload == null)
            {
                //LogStatus(String.Format(CultureInfo.CurrentCulture, "Error: {0}: {1}", title, error),
                //    NotifyType.ErrorMessage);
            }
            else
            {
                //LogStatus(String.Format(CultureInfo.CurrentCulture, "Error: {0} - {1}: {2}", upload.Guid, title,
                //    error), NotifyType.ErrorMessage);
            }

            return true;
        }
        // Note that this event is invoked on a background thread, so we cannot access the UI directly.
        private void UploadProgress(UploadOperation upload)
        {
            //MarshalLog(String.Format(CultureInfo.CurrentCulture, "Progress: {0}, Status: {1}", upload.Guid,
            //    upload.Progress.Status));

            var progress = upload.Progress;

            double percentSent = 100;
            if (progress.TotalBytesToSend > 0)
            {
                percentSent = progress.BytesSent * 100 / progress.TotalBytesToSend;
            }

            //MarshalLog(String.Format(CultureInfo.CurrentCulture,
            //    " - Sent bytes: {0} of {1} ({2}%), Received bytes: {3} of {4}", progress.BytesSent,
            //    progress.TotalBytesToSelect, percentSent, progress.BytesReceived, progress.TotalBytesToReceive));

            if (progress.HasRestarted)
            {
                //MarshalLog(" - Upload restarted");
            }

            if (progress.HasResponseChanged)
            {
                // We've received new response headers from the server.
                //MarshalLog(" - Response updated; Header count: " + upload.GetResponseInformation().Headers.Count);

                // If you want to stream the response data this is a good time to start.
                // upload.GetResultStreamAt(0);
            }
        }





        //private void MarshalLog(string value)
        //{
        //    var ignore = this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    {
        //        Log(value);
        //    });
        //}
    }
}
