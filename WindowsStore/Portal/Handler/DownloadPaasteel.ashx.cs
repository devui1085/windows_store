using System;
using System.IO;
using System.Web;

namespace Portal.Handler
{
    /// <summary>
    /// Summary description for DownloadPaasteel
    /// </summary>
    public class DownloadPaasteel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            UpPaasteelUserAppDownloadNumber();

            // get file name
            var filePath = context.Server.MapPath("~\\App_Data\\paasteel.appx");

            // check if the file exists
            if (File.Exists(filePath))
            {
                StartDownload(filePath);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 404;
                context.Response.Write("فایل مورد نظر یافت نشد.");
            }
        }

        private void UpPaasteelUserAppDownloadNumber()
        {
            try
            {
                // register download information
                //
                var client = new PaasteelPublicService.PublicServiceClient();
                client.UpPaasteelUserAppDownloadNumberByGuidAsync(Guid.Empty);
            }
            catch
            {
                // ignored
            }
        }

        private void StartDownload(string filePath)
        {
            var context = HttpContext.Current;

            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.AddHeader("Content-Disposition", "inline; filename=" + Path.GetFileName(filePath));

            context.Response.ContentType = "application/octet-stream";

            // for force download
            context.Response.BufferOutput = false;

            context.Response.TransmitFile(filePath);

            context.Response.End();
        }

        public bool IsReusable => false;
    }
}