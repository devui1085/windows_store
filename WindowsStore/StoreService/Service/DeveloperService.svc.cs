using Store.DomainService.Interface;
using System;
using System.ServiceModel;
using Store.StoreService.ServiceContract;
using Store.DataContract;
using Store.DataContract.SoapFaults;
using System.Collections.Generic;
using System.Linq;
using Store.StoreService.AppCode.Security;
using Store.Common.Infrastructure;
using Store.Common.InternalException;
using Store.DomainService.Core;
using Store.StoreService.AppCode.Common;
using Store.StoreService.AppCode.Extensibility;

namespace Store.StoreService.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceFaultBehavior]
    public class DeveloperService : IDeveloperService
    {
        private IUserManagementDomainService UserManagementDomainService { get; }
        private IAppDomainService AppDomainService { get; }

        public DeveloperService()
        {
            UserManagementDomainService = new UserManagementDomainService();
            AppDomainService = new AppDomainService();
        }

        public void RegisterNaturalPerson(NaturalPersonDataContract naturalPersonDataContract,string password)
        {
            UserManagementDomainService.RegisterNaturalPerson(naturalPersonDataContract, password, new string[] { "Developer" });
            UserManagementDomainService.SetNewActivationCode(naturalPersonDataContract.PrimaryEmail);
        }

        public void RegisterLegalPerson(LegalPersonDataContract legalPersonDataContract,string password)
        {
            UserManagementDomainService.RegisterLegalPerson(legalPersonDataContract,password);
            var verficationCode=   UserManagementDomainService.SetNewActivationCode(legalPersonDataContract.PrimaryEmail);

            // email verification code to user
            // send email to user
            ServiceEmailSender.SendVerificationEmailAsync(legalPersonDataContract.PrimaryEmail, verficationCode.ToString());
        }

        public AuthenticationResultDataContract SignIn(string userName, string password)
        {
            var result = UserManagementDomainService.SignIn(userName, password);

            if (!result.Authenticated) return result;

            // build user principal
            //
            var userPrincipal = new UserPrincipal
            {
                UserId = result.UserId,
                UserName = result.PrimaryEmail,
                Roles = UserManagementDomainService.GetPersonRoles(result.UserId).Select(r => r.Name).ToArray()
            };

            // register user principal in session
            Principal.CurrentUser = userPrincipal;

            return result;
        }



        public bool VerifyActiveSession(string userName)
        {
            if (Principal.CurrentUser == null)
                throw new FaultException<GeneralInternalFault>(new GeneralInternalFault()
                {
                    FaultCode = Common.Enum.FaultCode.Unauthorized
                });

            return true;
        }

        public bool AppNameIsAvailble(string appName,int appId)
        {
            return !AppDomainService.ExistsAppName(appName, appId);
        }


      

        public bool IsEmailAvailableForRegistration(string email)
        {
            return !UserManagementDomainService.ExistEmail(email);
        }

        public bool TryActivateAccount(string primaryEmail, int activationCode)
        {
            var success= UserManagementDomainService.ActivateAccount(primaryEmail, activationCode);

            if (success)
            {
                Principal.CurrentUser.Roles =
                    UserManagementDomainService.GetPersonRoles(Principal.CurrentUser.UserId).Select(r => r.Name).ToArray();
            }

            return success;
        }

        public bool ResendActivationCode(string email)
        {
            var isActivationCodeSent = false;
            try
            {
                var verficationCode = UserManagementDomainService.SetNewActivationCode(email).ToString();

                // send email to user
                ServiceEmailSender.SendVerificationEmailAsync(email, verficationCode);

                isActivationCodeSent = true;
            }
            catch
            {
                // ignored
            }
            return isActivationCodeSent;
        }

        public IEnumerable<AppCategoryDataContract> GetAppCategories()
        {
            return AppDomainService.GetAppCategories();
        }

        public void RegisterApp(AppDataContract appDataContract)
        {
            AppDomainService.RegisterApp(appDataContract);
        }

        public IEnumerable<AppDetailDataContract> GetDeveloperApps()
        {
            return AppDomainService.GetDeveloperApps(Principal.CurrentUser.UserId);
        }

        public AppDetailDataContract GetDeveloperAppDetail(int appId)
        {
            return AppDomainService.GetDeveloperAppDetail(Principal.CurrentUser.UserId, appId);
        }
     
        public AppSpecificationDataContract RegisterAppSpecification(AppSpecificationDataContract appSpecification)
        {

            return AppDomainService.RegisterAppSpecification(appSpecification, Principal.CurrentUser.UserId);
        }

        public void UpdateAppSpecification(AppSpecificationDataContract appSpecification)
        {
            AppDomainService.UpdateAppSpecification(appSpecification);
        }

        public void RegisterAppIcon(AppIconDataContract appIconDataContract)
        {
            AppDomainService.RegisterAppIcon(appIconDataContract);
        }

        public void RegisterAppPlatformSpecification(AppPlatformSpecificationDataContract appPlatformSpecificationDataContract)
        {
            AppDomainService.RegisterAppPlatformSpecification(appPlatformSpecificationDataContract);
        }

        public AppVersionDataContract RegisterAppVersion(AppVersionDataContract appVersionDataContract)
        {
           return AppDomainService.RegisterAppVersion(appVersionDataContract);
        }

        public void UpdateAppVersion(AppVersionDataContract appVersionDataContract)
        {
            AppDomainService.UpdateAppVersion(appVersionDataContract);
        }

        public void SaveScreenshot(ScreenshotDataContract screenshot)
        {
            AppDomainService.SaveScreenshot(screenshot);
        }

        public void RemoveScreenshot(ScreenshotDataContract screenshot)
        {
            AppDomainService.RemoveScreenshot(screenshot, Principal.CurrentUser.UserId);
        }

        public ScreenshotDataContract GetScreenshot(ScreenshotFilterDataContract filter)
        {
            return AppDomainService.GetScreenshot(filter);
           
        }

        public List<int> GetScreenshotIds(ScreenshotFilterDataContract fitler)
        {
            return AppDomainService.GetScreenshotIds(fitler);
        }
        #region Samples

        public void SetRealSession(string name)
        {
            try
            {
                throw new NullReferenceException("Session is null");
            }
            catch (NullReferenceException)
            {
                AuthenticationFault authenticationFault = new AuthenticationFault
                {
                    Reason = "Exception accessing session",
                    Message = "This is test message"
                };

                throw new FaultException<AuthenticationFault>(authenticationFault);
            }
        }

        #endregion


    }
}
