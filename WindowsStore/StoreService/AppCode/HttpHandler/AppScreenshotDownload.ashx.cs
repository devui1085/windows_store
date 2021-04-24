using Store.Common.Enum;
using Store.DomainService.Core;
using Store.DomainService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.StoreService.AppCode.HttpHandler
{
    public class AppScreenshot : IHttpHandler
    {
        public IAppDomainService AppDomainService { get; set; }

        public AppScreenshot()
        {
            AppDomainService = new AppDomainService();
        }

        public void ProcessRequest(HttpContext context)
        {
            var headers = HttpContext.Current.Request.Headers;
            var appGuid = Guid.Parse(headers.Get("appGuid"));
            var screenshotSize = (ScreenshotSize)Enum.Parse(typeof(ScreenshotSize), headers.Get("screenshotSize"));
            var screenshotType = (ScreenshotType)Enum.Parse(typeof(ScreenshotType), headers.Get("screenshotType"));
            var screenshotIndex = int.Parse(headers.Get("screenshotIndex"));
            var path = AppDomainService.GetAppScreenshotFilePath(appGuid, screenshotType, screenshotSize, screenshotIndex);
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