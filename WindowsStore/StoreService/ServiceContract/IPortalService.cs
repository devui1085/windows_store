using System;
using System.Collections.Generic;
using System.ServiceModel;
using Store.DataContract;

namespace Store.StoreService.ServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPortalService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed, Namespace = "Paasteel.ir")]
    public interface IPortalService
    {
        [OperationContract]
        IEnumerable<AppCategoryDataContract> GetAppCategories();

        [OperationContract]
        AppDataContract GetAppDetail(AppFilterDataContract filter);

        [OperationContract]
        ScreenshotDataContract GetAppScreenshot(ScreenshotFilterDataContract filter);

        [OperationContract]
        IEnumerable<AppDataContract> GetSpecialApps();

        [OperationContract]
        IEnumerable<AppDataContract> GetMostPopularApps();

        [OperationContract]
        IEnumerable<AppDataContract> GetChosenApps();

        [OperationContract]
        IEnumerable<AppDataContract> GetNewApps();

        [OperationContract]
        IEnumerable<AppDataContract> GetSpecialGames();

        [OperationContract]
        IEnumerable<AppDataContract> GetMostPopularGames();

        [OperationContract]
        IEnumerable<AppDataContract> GetChosenGames();

        [OperationContract]
        IEnumerable<AppDataContract> GetNewGames();

        [OperationContract]
        byte[] GetAppIcon128(Guid guid);

        [OperationContract]
        byte[] GetAppIcon256(Guid guid);
    }
}
