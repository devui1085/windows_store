using Store.Common.Configuration;
using Store.Common.Enum;
using Store.DataContract;
using Store.DomainService.Core;
using Store.DomainService.Interface;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace Store.StoreService.AppCode.HttpHandler
{
    public class AppDownload : IHttpHandler
    {
        readonly string _appsDirectoryPath;

        public IAppDomainService AppDomainService { get; set; }
        public bool IsReusable => true;

        public AppDownload()
        {
            AppDomainService = new AppDomainService();
            _appsDirectoryPath = ConfigurationReader.AppsDirectoryPath;
        }

        public void ProcessRequest(HttpContext context)
        {
            try {
                var appGuid = Guid.Parse(context.Request.QueryString["appguid"]);
                var app = AppDomainService.GetAppDetail(appGuid, false, false, false);

                var filePath = GetAppPackagePath(app);
                WriteFileToResponse(filePath, context, app);
            }
            catch (Exception) {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            finally {
                context.Response.End();
            }
        }

        private string GetAppPackagePath(AppDataContract app)
        {
            return $"{_appsDirectoryPath}\\{app.Guid}\\arm.pstl";
        }

        private void WriteFileToResponse(string filePath, HttpContext context, AppDataContract app)
        {
            const string sampleETag = "\"SampleETag\"";
            byte[] buffer = new byte[4096];

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                var fullContentLength = fileStream.Length;
                var offset = 0;
                var contentLength = fullContentLength;

                // Check if we have a request for partial content (resume scenarios).
                if (string.CompareOrdinal(sampleETag, context.Request.Headers["If-Range"]) == 0) {
                    GetRange(context.Request.Headers["Range"], fullContentLength, out offset, out contentLength);
                }

                if (offset > 0) {
                    // Resume Download
                    context.Response.StatusCode = (int)HttpStatusCode.PartialContent; ;
                    context.Response.Headers["Content-Range"] =
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                            "bytes {0}-{1}/{2}", offset, offset + contentLength - 1, fullContentLength);
                }
                else {
                    // Start Download
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                }

                context.Response.ContentType = "application/octet-stream";
                context.Response.Headers["Content-Length"] =
                    contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture);
                context.Response.Headers["Accept-Ranges"] = "bytes";
                context.Response.Headers["ETag"] = sampleETag;
                context.Response.Buffer = false;

                var transferLength = contentLength;

                if (offset > 0)
                    fileStream.Seek(offset, SeekOrigin.Begin);

                while (transferLength > 0) {
                    //Thread.Sleep(50); // For Debug
                    fileStream.Read(buffer, 0, buffer.Length);

                    var sendLength = (int)Math.Min(transferLength, buffer.Length);
                    context.Response.OutputStream.Write(buffer, 0, sendLength);
                    transferLength -= sendLength;
                }

                AppDomainService.IncrementAppLatestVersionDownloads(app.Guid);
            }
        }

        private void GetRange(string rangeHeaderValue, long fullContentLength, out int offset, out long length)
        {
            offset = 0;
            length = fullContentLength;

            if (string.IsNullOrEmpty(rangeHeaderValue)) {
                return;
            }

            var rx = new Regex(@"(bytes)\s*=\s*(?<startIndex>\d+)\s*-\s*(?<endIndex>\d+)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match match = rx.Match(rangeHeaderValue);

            int startIndex;
            Capture startIndexCapture = match.Groups["startIndex"];
            if ((startIndexCapture == null) || (!int.TryParse(startIndexCapture.Value, out startIndex))) {
                return;
            }

            offset = startIndex;

            int endIndex;
            Capture endIndexCapture = match.Groups["endIndex"];
            if ((endIndexCapture != null) && (int.TryParse(endIndexCapture.Value, out endIndex))) {
                length = endIndex - offset + 1;
            }
            else {
                length = fullContentLength - offset;
            }
        }
    }
}