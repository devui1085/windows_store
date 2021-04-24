using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Services
{
   public class FakeServiceProxy : IDeveloperService
    {
       public Task<ObservableCollection<AppCategoryDataContract>> GetAppCategoriesAsync()
       {
           throw new NotImplementedException();
       }

       public Task RegisterAppAsync(AppDataContract appDataContract)
       {
           throw new NotImplementedException();
       }

       public Task RegisterNaturalPersonAsync(NaturalPersonDataContract naturalPersonDataContract, string password)
       {
           throw new NotImplementedException();
       }

       public Task RegisterLegalPersonAsync(LegalPersonDataContract legalPersonDataContract, string password)
       {
           throw new NotImplementedException();
       }

       public Task<AuthenticationResultDataContract> SignInAsync(string userName, string password)
       {
           throw new NotImplementedException();
       }

       public Task<bool> IsEmailAvailableForRegistrationAsync(string email)
       {
           throw new NotImplementedException();
       }

       public Task<bool> TryActivateAccountAsync(string primaryEmail, int activationCode)
       {
           throw new NotImplementedException();
       }

       public Task<bool> ResendActivationCodeAsync(string email)
       {
           throw new NotImplementedException();
       }

       public Task<ObservableCollection<AppDetailDataContract>> GetDeveloperAppsAsync()
       {
           throw new NotImplementedException();
       }

       public Task<AppDetailDataContract> GetDeveloperAppDetailAsync(int appId)
       {
           throw new NotImplementedException();
       }

       public Task<bool> VerifyActiveSessionAsync(string userName)
       {
           throw new NotImplementedException();
       }

       public Task<bool> AppNameIsAvailbleAsync(string appName, int appId)
       {
           throw new NotImplementedException();
       }

       public Task<bool> AppNameIsAvailbleAsync(string appName)
       {
           throw new NotImplementedException();
       }

       public Task<AppSpecificationDataContract> RegisterAppSpecificationAsync(AppSpecificationDataContract appSpecification)
       {
           throw new NotImplementedException();
       }

       public Task UpdateAppSpecificationAsync(AppSpecificationDataContract appSpecification)
       {
           throw new NotImplementedException();
       }

       public Task RegisterAppIconAsync(AppIconDataContract appIconDataContract)
       {
           throw new NotImplementedException();
       }

       public Task RegisterAppPlatformSpecificationAsync(AppPlatformSpecificationDataContract appPlatformSpecificationDataContract)
       {
           throw new NotImplementedException();
       }

       public Task RegisterAppVersionAsync(AppVersionDataContract appVersionDataContract)
       {
           throw new NotImplementedException();
       }

       public Task UpdateAppVersionAsync(AppVersionDataContract appVersionDataContract)
       {
           throw new NotImplementedException();
       }

       public Task SaveScreenshotAsync(ScreenshotDataContract screenshot)
       {
           throw new NotImplementedException();
       }

       public Task RemoveScreenshotAsync(ScreenshotDataContract screenshot)
       {
           throw new NotImplementedException();
       }

       public Task<ScreenshotDataContract> GetScreenshotAsync(ScreenshotFilterDataContract filter)
       {
           throw new NotImplementedException();
       }

       public Task<ObservableCollection<int>> GetScreenshotIdsAsync(ScreenshotFilterDataContract fitler)
       {
           throw new NotImplementedException();
       }

       public Task<ScreenshotDataContract> GetAppScreenshotAsync(ScreenshotFilterDataContract filter)
       {
           throw new NotImplementedException();
       }

       public Task<ScreenshotDataContract> GetAppScreenShotAsync(ScreenshotFilterDataContract filter)
       {
           throw new NotImplementedException();
       }

       Task<AppVersionDataContract> IDeveloperService.RegisterAppVersionAsync(AppVersionDataContract appVersionDataContract)
        {
            throw new NotImplementedException();
        }
    }
}
