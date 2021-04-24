using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ServiceInterface
{
    public interface IClientDeveloperService
    {
        Task<bool> VerifyActiveSessionAsync(string userName);
        Task<LogOnResult> SignInAsync(string userName, string password);
        Task RegisterNaturalPersonAsync(NaturalPerson naturalPerson, string password);
        Task RegisterLegalPersonAsync(LegalPerson legalPerson, string password);
        Task<bool> IsEmailAvailableForRegistrationAsync(string email);
        Task<bool> TryActivateAccountAsync(string primaryEmail, int activationCode);
        Task<bool> ResendActivationCodeAsync(string email);
        Task<IEnumerable<Task<AppDetail>>> GetDeveloperAppsAsync();
        Task<AppDetail> GetDeveloperAppDetailAsync(int appId);
        Task<IEnumerable<AppCategory>> GetAppCategoriesAsync();
        Task<bool> AppNameIsAvailbleAsync(string appName, int appId);
        Task<AppSpecification> RegisterAppSpecificationAsync(
            AppSpecification appSpecification);
        Task UpdateAppSpecificationAsync(AppSpecification appSpecification);
        Task RegisterAppIconAsync(AppIcon appIconDataContract);

        Task RegisterAppPlatformSpecificationAsync(AppPlatformSpecification appPlatformSpecification);

        Task<AppVersion> RegisterAppVersionAsync(AppVersion appVersion);
        Task UpdateAppVersionAsync(AppVersion appVersion);

        Task SaveScreenshotAsync(AppScreenshot screenshot);

        Task RemoveScreenshotAsync(AppScreenshot screenshot);

        Task<AppScreenshot> GetScreenshotAsync(AppScreenshotFilter filter);
        Task<List<int>> GetScreenshotIdsAsync(AppScreenshotFilter filter);
    }
}
