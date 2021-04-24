using System;
using System.ServiceModel;
using Store.StoreService.ServiceContract;
using Store.DataContract;
using Store.StoreService.AppCode.Extensibility;
using System.Collections.Generic;
using Store.DomainService.Interface;
using Store.DomainService.Core;
using Store.StoreService.AppCode.Security;
using System.Linq;
using Store.StoreService.AppCode.Common;
using System.Web;

namespace Store.StoreService.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [ServiceFaultBehavior]
    public class UserService : IUserService
    {
        private IAppDomainService AppDomainService { get; }
        private IUserManagementDomainService UserManagementDomainService { get; }
        private IDeviceManagementDomainService DeviceManagementDomainService { get; }


        public UserService()
        {
            AppDomainService = new AppDomainService();
            UserManagementDomainService = new UserManagementDomainService();
            DeviceManagementDomainService = new DeviceManagementDomainService();
        }

        #region App Management
        public IEnumerable<AppCategoryDataContract> GetAppCategories()
        {
            return AppDomainService.GetAppCategories();
        }


        public IEnumerable<AppDataContract> GetApps(AppFilterDataContract filter)
        {
            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetRandomApps(AppFilterDataContract filter)
        {
            return AppDomainService.GetRandomApps(filter);
        }

        public AppDataContract GetAppDetail(AppFilterDataContract filter)
        {
            return AppDomainService.GetAppDetail(filter, true);
        }

        public IEnumerable<AppVersionDataContract> GetAppsLatestVersionInfo(IEnumerable<Guid> appGuids)
        {
            return AppDomainService.GetAppsLatestVersionInfo(appGuids);
        }

        public ScreenshotDataContract GetAppScreenshot(ScreenshotFilterDataContract filter)
        {
            return AppDomainService.GetAppScreenshot(filter);
        }

        #endregion

        #region User Management

        public void RegisterNaturalPerson(NaturalPersonDataContract naturalPersonDataContract, string password)
        {
            UserManagementDomainService.RegisterNaturalPerson(naturalPersonDataContract, password, new string[] { });
            var verficationCode = UserManagementDomainService.SetNewActivationCode(naturalPersonDataContract.PrimaryEmail);
            ServiceEmailSender.SendVerificationEmailAsync(naturalPersonDataContract.PrimaryEmail, verficationCode.ToString());
        }

        public AuthenticationResultDataContract SignIn(string userName, string password)
        {
            var result = UserManagementDomainService.SignIn(userName, password);
            if (!result.Authenticated)
                return result;

            // register user principal in session
            Principal.CurrentUser = new UserPrincipal
            {
                UserId = result.UserId,
                UserName = result.PrimaryEmail,
                Roles = UserManagementDomainService.GetPersonRoles(result.UserId).Select(r => r.Name).ToArray()
            };

            return result;
        }

        public bool IsEmailAvailableForRegistration(string email)
        {
            return !UserManagementDomainService.ExistEmail(email);
        }

        public bool TryActivateAccount(int activationCode)
        {
            var email = Principal.CurrentUser.UserName;
            return UserManagementDomainService.ActivateAccount(email, activationCode);
        }

        public void ResendActivationCode()
        {
            var email = Principal.CurrentUser.UserName;
            var verficationCode = UserManagementDomainService.SetNewActivationCode(email).ToString();
            ServiceEmailSender.SendVerificationEmailAsync(email, verficationCode);
        }

        public void SignOut()
        {
            HttpContext.Current.Session.Abandon();
        }

        public ServerDescriptorDataContract GetServerDescriptor(UserClientDescriptorDataContract userClientDescriptor)
        {
            return AppDomainService.GetServerDescriptor(userClientDescriptor);
        }

        #endregion

        #region Device Registration
        public ServerDescriptorDataContract RegisterDevice(UserClientDescriptorDataContract descriptor)
        {
            return DeviceManagementDomainService.RegisterDevice(descriptor);
        }

        #endregion
    }
}
