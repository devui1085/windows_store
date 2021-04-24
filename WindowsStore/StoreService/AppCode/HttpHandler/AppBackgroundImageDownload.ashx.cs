using Store.DomainService.Core;
using Store.DomainService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.StoreService.AppCode.HttpHandler
{
    public class AppBackgroundImageDownload : IHttpHandler
    {
        public IAppDomainService AppDomainService { get; set; }

        public AppBackgroundImageDownload()
        {
            AppDomainService = new AppDomainService();
        }

        public void ProcessRequest(HttpContext context)
        {
            var appGuid = Guid.Parse(context.Request.QueryString["appGuid"]);
            var path = AppDomainService.GetAppBackgroundFilePath(appGuid);
            context.Response.WriteFile(path);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}