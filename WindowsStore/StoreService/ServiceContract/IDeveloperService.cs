using Store.StoreService.AppCode.Security;
using Store.Common.Infrastructure;
using Store.DataContract;
using System.Collections.Generic;
using System.ServiceModel;
using Store.DataContract.SoapFaults;

namespace Store.StoreService.ServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeveloperService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed, Namespace = "Paasteel.ir")]
    public interface IDeveloperService 
    {
        #region App Service

        [OperationContract]
        IEnumerable<AppCategoryDataContract> GetAppCategories();

        [OperationContract]
        void RegisterApp(AppDataContract appDataContract);

        #endregion

        #region User Management Service

        [OperationContract]
        void RegisterNaturalPerson(NaturalPersonDataContract naturalPersonDataContract,string password);

        [OperationContract]
        void RegisterLegalPerson(LegalPersonDataContract legalPersonDataContract, string password);

        [OperationContract]
        [FaultContract(typeof(GeneralInternalFault))]
        AuthenticationResultDataContract SignIn(string userName, string password);

        [OperationContract]
        [FaultContract(typeof(GeneralInternalFault))]
        bool IsEmailAvailableForRegistration(string email);

        [OperationContract]
        bool TryActivateAccount(string primaryEmail, int activationCode);

        [OperationContract]
        bool ResendActivationCode(string email);

        #endregion

        [OperationContract]
        //[FaultContract(typeof(AuthenticationFault))]
        [FaultContract(typeof(GeneralInternalFault))]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        IEnumerable<AppDetailDataContract> GetDeveloperApps();

        [OperationContract]
        [FaultContract(typeof (GeneralInternalFault))]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        AppDetailDataContract GetDeveloperAppDetail(int appId);


        [OperationContract]
        [FaultContract(typeof(GeneralInternalFault))]
        bool VerifyActiveSession(string userName);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        bool AppNameIsAvailble(string appName, int appId);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        AppSpecificationDataContract RegisterAppSpecification(AppSpecificationDataContract appSpecification);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        void UpdateAppSpecification(AppSpecificationDataContract appSpecification);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        void RegisterAppIcon(AppIconDataContract appIconDataContract);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames ="Developer")]
        void RegisterAppPlatformSpecification(AppPlatformSpecificationDataContract appPlatformSpecificationDataContract);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames ="Developer")]
        AppVersionDataContract RegisterAppVersion(AppVersionDataContract appVersionDataContract);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames ="Developer")]
        void UpdateAppVersion(AppVersionDataContract appVersionDataContract);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames ="Developer")]
        void SaveScreenshot(ScreenshotDataContract screenshot);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        void RemoveScreenshot(ScreenshotDataContract screenshot);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        ScreenshotDataContract GetScreenshot(ScreenshotFilterDataContract filter);

        [OperationContract]
        [AuthorizeOperationBehavior(RoleNames = "Developer")]
        List<int> GetScreenshotIds(ScreenshotFilterDataContract fitler);
    }
}
