using Store.DataContract;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Store.StoreService.ServiceContract
{
    [ServiceContract(SessionMode = SessionMode.Allowed, Namespace = "Paasteel.com")]
    public interface IUserService 
    {
        #region App Management
        [OperationContract]
        IEnumerable<AppCategoryDataContract> GetAppCategories();

        [OperationContract]
        IEnumerable<AppDataContract> GetApps(AppFilterDataContract filter);

        [OperationContract]
        IEnumerable<AppDataContract> GetRandomApps(AppFilterDataContract filter);

        [OperationContract]
        AppDataContract GetAppDetail(AppFilterDataContract filter);

        [OperationContract]
        IEnumerable<AppVersionDataContract> GetAppsLatestVersionInfo(IEnumerable<Guid> appGuids);

        [OperationContract]
        ScreenshotDataContract GetAppScreenshot(ScreenshotFilterDataContract filter);

        #endregion

        #region User Management
        [OperationContract]
        void RegisterNaturalPerson(NaturalPersonDataContract naturalPersonDataContract, string password);

        [OperationContract]
        AuthenticationResultDataContract SignIn(string userName, string password);

        [OperationContract]
        void SignOut();

        [OperationContract]
        bool IsEmailAvailableForRegistration(string email);

        [OperationContract]
        bool TryActivateAccount(int activationCode);

        [OperationContract]
        void ResendActivationCode();
        #endregion

        #region Device Registration
        [OperationContract]
        ServerDescriptorDataContract RegisterDevice(UserClientDescriptorDataContract descriptor);
        #endregion

        [Obsolete]
        [OperationContract]
        ServerDescriptorDataContract GetServerDescriptor(UserClientDescriptorDataContract userClientDescriptor);
    }
}
