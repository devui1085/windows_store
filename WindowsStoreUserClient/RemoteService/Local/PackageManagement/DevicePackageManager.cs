using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using System;
using System.IO;
using Windows.Web.Http.Filters;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http;
using Windows.Data.Json;

namespace WindowsStore.Client.User.Service.Local.PackageManagement
{
    public static class DevicePackageManager
    {
        // Fields
        static HttpClient _httpClient;

        public static async Task<bool> LaunchInstallerAsync(IStorageFile appPackage)
        {
            bool result;
            try {
                result = await Launcher.LaunchFileAsync(appPackage);
            }
            catch {
                result = false;
            }
            return result;
        }

        private static HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null) {
                    var filter = new HttpBaseProtocolFilter();
                    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
                    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
                    _httpClient = new Windows.Web.Http.HttpClient(filter);
                }
                return _httpClient;
            }
        }

        public static async Task<PackageInstallationResult> InstallAppAsync(IStorageFile appPackage, Guid decryptionKey)
        {
            var filename = "app.appx";
            var deployUri = new Uri("https://localhost/api/app/packagemanager/package?package=" + filename);

            // Prepare Request for deploying app
            var stream = new PackageReader(await appPackage.OpenAsync(FileAccessMode.ReadWrite), decryptionKey);
            var httpContent = new Windows.Web.Http.HttpStreamContent(stream);
            await httpContent.BufferAllAsync();
            var multipartContent = new HttpMultipartFormDataContent();
            multipartContent.Add(httpContent, filename, filename);
            HttpResponseMessage response;

            // Send request
            bool requestSucessfull;
            try {
                response = await HttpClient.PostAsync(deployUri, multipartContent);
                requestSucessfull = response.IsSuccessStatusCode;
            }
            catch (Exception ex) {
                requestSucessfull = false;
            }

            // Request was sucessfull ?
            if (!requestSucessfull) {
                return PackageInstallationResult.ConnectToDevicePortalFailed;
            }

            // Waiting for response
            return await GetInstallationResultAsync();
        }

        private static async Task<PackageInstallationResult> GetInstallationResultAsync()
        {
            var checkForStatus = true;
            PackageInstallationResult installationResult = null;

            while (checkForStatus) {
                try {
                    installationResult = await CheckForInstallationResultAsync();
                    await Task.Delay(1000);
                    checkForStatus = (installationResult == null);
                }
                catch {
                    installationResult = PackageInstallationResult.ConnectToDevicePortalFailed;
                    checkForStatus = false;
                }
            }

            return installationResult;
        }

        private static async Task<PackageInstallationResult> CheckForInstallationResultAsync()
        {
            JsonObject jsonObject;
            var deployStatusUri = new Uri("https://localhost/api/app/packagemanager/state");
            var response = await HttpClient.GetStringAsync(deployStatusUri);

            if (JsonObject.TryParse(response, out jsonObject)) {
                return new PackageInstallationResult()
                {
                    Code = (long)jsonObject.GetNamedNumber("Code", 0),
                    CodeText = jsonObject.GetNamedString("CodeText", ""),
                    Reason = jsonObject.GetNamedString("Reason", ""),
                    Success = jsonObject.GetNamedBoolean("Success", false)
                };
            }

            return null;
        }

    }
}
