using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ModelMapping;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using System.Linq;

namespace WindowsStore.Client.Developer.Logic.Services
{
    public class DeveloperServiceProxy : IClientDeveloperService
    {
        private readonly IDeveloperService _developerService;

        public DeveloperServiceProxy()
        {
            _developerService = new ServiceFactory<IDeveloperService>().GetService();
        }

        #region AccountingService
        public async Task<bool> VerifyActiveSessionAsync(string userName)
        {
            var result = await _developerService.VerifyActiveSessionAsync(userName);
            return result;
        }


        public async Task<LogOnResult> SignInAsync(string userName, string password)
        {
            var result = await _developerService.SignInAsync(userName, password);
            return result.ToLogOnResult();
        }

        public async Task RegisterLegalPersonAsync(LegalPerson legalPerson,string password)
        {
            await _developerService.RegisterLegalPersonAsync(legalPerson.ToLegalPersonDataContract(),password);
        }

        public async Task RegisterNaturalPersonAsync(NaturalPerson naturalPerson,string password)
        {
            await _developerService.RegisterNaturalPersonAsync(naturalPerson.ToNaturalPersonDataContract(),password);
        }


        public async Task<bool> IsEmailAvailableForRegistrationAsync(string email)
        {
            var result= await _developerService.IsEmailAvailableForRegistrationAsync(email);
            return result;
        }

        public async Task<bool> TryActivateAccountAsync(string primaryEmail, int activationCode)
        {
            var result = await _developerService.TryActivateAccountAsync(primaryEmail, activationCode);
            return result;
        }

        public async Task<bool> ResendActivationCodeAsync(string email)
        {
            var result = await _developerService.ResendActivationCodeAsync(email);
            return result;
        }

        public async Task<IEnumerable<Task<AppDetail>>> GetDeveloperAppsAsync()
        {
            var result = await _developerService.GetDeveloperAppsAsync();
            var developerApps = result.Select(async a => await a.ToAppDetailAsync());
            return developerApps;
        }

        public async Task<AppDetail> GetDeveloperAppDetailAsync(int appId)
        {
            var result = await _developerService.GetDeveloperAppDetailAsync(appId);
            var appDetail = await result.ToAppDetailAsync();

            return appDetail;
        }

        public async Task<IEnumerable<AppCategory>> GetAppCategoriesAsync()
        {
            var result = await _developerService.GetAppCategoriesAsync();
            return result.Select(c => c.ToAppCategory());
        }

        public async Task<bool> AppNameIsAvailbleAsync(string appName,int appId)
        {
            var result = await _developerService.AppNameIsAvailbleAsync(appName, appId);
            return result;
        }

        public async Task<AppSpecification> RegisterAppSpecificationAsync(AppSpecification appSpecification)
        {
            var result =
                await _developerService.RegisterAppSpecificationAsync(appSpecification.ToAppSpecificationDataContract());
            return result.ToAppSpecification();
        }

        public Task UpdateAppSpecificationAsync(AppSpecification appSpecification)
        {
            return _developerService.UpdateAppSpecificationAsync(appSpecification.ToAppSpecificationDataContract());
        }

        public async Task RegisterAppIconAsync(AppIcon appIcon)
        {
            var result =await appIcon.ToAppIconDataContract();
            await _developerService.RegisterAppIconAsync(result);
        }

        public async Task RegisterAppPlatformSpecificationAsync(AppPlatformSpecification appPlatformSpecification)
        {
            await _developerService.RegisterAppPlatformSpecificationAsync(appPlatformSpecification.ToAppPlatformSpecificationDataContract());
        }

        public async Task<AppVersion> RegisterAppVersionAsync(AppVersion appVersion)
        {
            var result = await _developerService.RegisterAppVersionAsync(appVersion.ToAppVersionDataContract());
            return result.ToAppVersion();
        }

        public async Task UpdateAppVersionAsync(AppVersion appVersion)
        {
            await _developerService.UpdateAppVersionAsync(appVersion.ToAppVersionDataContract());
        }

        public async Task SaveScreenshotAsync(AppScreenshot screenshot)
        {
            await _developerService.SaveScreenshotAsync(await screenshot.ToAppScreenshotDataContract());
        }

        public async Task RemoveScreenshotAsync(AppScreenshot screenshot)
        {
            await _developerService.RemoveScreenshotAsync(await screenshot.ToAppScreenshotDataContract());
        }



        public async Task<AppScreenshot> GetScreenshotAsync(AppScreenshotFilter filter)
        {
            var result = await _developerService.GetScreenshotAsync(filter.ToScreenshotFilterDataContract());
            var screenshot = await result.ToAppScreenshotAsync();
            return screenshot;
        }

        public async Task<List<int>> GetScreenshotIdsAsync(AppScreenshotFilter filter)
        {
            var result = await _developerService.GetScreenshotIdsAsync(filter.ToScreenshotFilterDataContract());
            return result.ToList();
        }
        #endregion

        #region AppService


        #endregion
    }
}
