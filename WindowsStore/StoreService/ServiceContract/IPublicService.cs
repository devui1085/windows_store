using System;
using System.ServiceModel;

namespace Store.StoreService.ServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPublicService" in both code and config file together.
    [ServiceContract]
    public interface IPublicService
    {

        [OperationContract]
        void UpPaasteelUserAppDownloadNumberById(int appId);
        [OperationContract]
        void UpPaasteelUserAppDownloadNumberByGuid(Guid guid);
    }
}
