using System;
using System.ServiceModel;
using System.Web;
using Store.DomainService.Core;
using Store.DomainService.Interface;
using Store.StoreService.AppCode.Extensibility;
using Store.StoreService.ServiceContract;

namespace Store.StoreService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PublicService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PublicService.svc or PublicService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [ServiceFaultBehavior]
    public class PublicService : IPublicService
    {
        private IAppDomainService AppDomainService { get; }

        public PublicService()
        {
                 AppDomainService = new AppDomainService(); 
        }

        public void UpPaasteelUserAppDownloadNumberById(int appId)
        {
          //  HttpContext.Current.Request.UrlReferrer
            AppDomainService.IncrementAppLatestVersionDownloads(appId);
        }

        public void UpPaasteelUserAppDownloadNumberByGuid(Guid guid)
        {
            AppDomainService.IncrementAppLatestVersionDownloads(guid);
        }
    }
}
