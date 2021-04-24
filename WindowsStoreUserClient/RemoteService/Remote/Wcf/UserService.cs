using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Remote.ModelMapping;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.Wcf
{
    internal class UserService : RemoteServiceBase
    {
        public UserService()
        {

        }

        #region App Management
        public async Task<IEnumerable<AppCategory>> GetAppCategoriesAsync()
        {
            return (await RemoteUserService.GetAppCategoriesAsync())
                .Select(appCategoryDC => appCategoryDC.GetAppCategory());
        }

        public async Task<IEnumerable<StoreApp>> GetAppsAsync(AppQueryParameters appQueryParameters)
        {
            var appsDC = await RemoteUserService.GetAppsAsync(appQueryParameters.GetAppQueryParametersDC());
            var apps = appsDC.Select(appDC => appDC.GetStoreApp()).ToList();

            foreach (var app in apps) {
                app.Icon128x128 = await app.Icon128x128Bytes.ConvertToBitmapImageAsync();

            }

            this.Close();
            return apps;
        }

        public async Task<IEnumerable<StoreApp>> GetRandomAppsAsync(AppQueryParameters appQueryParameters)
        {
            var appsDC = await RemoteUserService.GetRandomAppsAsync(appQueryParameters.GetAppQueryParametersDC());
            var apps = appsDC.Select(appDC => appDC.GetStoreApp()).ToList();
            foreach (var app in apps) {
                app.Icon128x128 = await app.Icon128x128Bytes.ConvertToBitmapImageAsync();
            }
            this.Close();
            return apps;
        }


        public async Task<StoreApp> GetAppDetailsAsync(AppQueryParameters appQueryParameters)
        {
            var app = (await RemoteUserService.GetAppDetailAsync(appQueryParameters.GetAppQueryParametersDC())).GetStoreApp();
            this.Close();
            return app;
        }

        public async Task<IEnumerable<AppVersion>> GetAppsLatestVersionInfoAsync(IEnumerable<Guid> appGuids)
        {
            var latestVersions =
                (await RemoteUserService.GetAppsLatestVersionInfoAsync(appGuids.ToArray()))
                .Select(version => version.GetAppVersion());
            this.Close();
            return latestVersions;
        }

        public async Task<Screenshot> GetAppScreenShotAsync(
            Guid appGuid,
            AppScreenshotSize screenShotSize,
            AppScreenshotType screenShotType,
            int screenShotIndex)
        {
            var screenShotDC = await RemoteUserService.GetAppScreenshotAsync(new ScreenshotFilterDataContract()
            {
                AppGuid = appGuid,
                ScreenshotSize = (ScreenshotSize)screenShotSize,
                ScreenshotType = (ScreenshotType)screenShotType,
                ScreenshotIndex = screenShotIndex
            });

            this.Close();
            return await screenShotDC.GetScreenShotAsync();
        }


        #endregion

        #region User Management

        public async Task<AuthenticationResult> SignInAsync(string username, string password)
        {
            var result = (await RemoteUserService.SignInAsync(username, password)).GetAuthenticationResult();
            this.Close();
            return result;
        }

        public async Task SignOutAsync()
        {
            await RemoteUserService.SignOutAsync();
            this.Close();
        }

        public async Task RegisterNaturalPersonAsync(NaturalPerson naturalPerson)
        {
            await RemoteUserService.RegisterNaturalPersonAsync(naturalPerson.GetNaturalPersonDC(), naturalPerson.Password);
            this.Close();
        }

        public async Task<ServerDescriptor> GetServerDiscriptorAsync(UserClientDescriptor descriptor)
        {
            var serverDescriptor = (await RemoteUserService.GetServerDescriptorAsync(descriptor.GetUserClientrDescriptorDC()))
                .GetServerDescriptor();
            this.Close();
            return serverDescriptor;
        }
        public async Task<bool> IsEmailAvailableForRegistration(string email)
        {
            var result = await RemoteUserService.IsEmailAvailableForRegistrationAsync(email);
            this.Close();
            return result;
        }

        public async Task<bool> TryActivateAccountAsync(int activationCode)
        {
            var result = await RemoteUserService.TryActivateAccountAsync(activationCode);
            this.Close();
            return result;
        }

        public async Task ResendActivationCodeAsync()
        {
            await RemoteUserService.ResendActivationCodeAsync();
            this.Close();
        }
        #endregion

        #region Device Registration
        public async Task<ServerDescriptor> RegisterDeviceAsync(UserClientDescriptor descriptor)
        {
            var result = await RemoteUserService.RegisterDeviceAsync(descriptor.GetUserClientrDescriptorDC());
            this.Close();
            return result.GetServerDescriptor();
        }
        #endregion
    }
}
