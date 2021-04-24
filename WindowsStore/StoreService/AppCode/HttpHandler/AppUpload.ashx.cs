using System;
using System.IO;
using System.Web;
using Store.Common.Configuration;
using Store.DomainService.Core;
using Store.DomainService.Interface;
using Store.StoreService.AppCode.Security;

namespace Store.StoreService.AppCode.HttpHandler
{
    /// <summary>
    /// Summary description for AppUpload
    /// </summary>
    public class AppUpload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Headers["Filename"] == null)
                  throw new HttpRequestValidationException();

            try
            {
                // save file on file system
                //
                var appGuid = context.Request.Headers["Guid"];
                var appName = context.Request.Headers["AppName"];

                var saveLocation = ConfigurationReader.AppsDirectoryPath + "\\" + appGuid;

                if (!Directory.Exists(saveLocation))
                    Directory.CreateDirectory(saveLocation);

                var fileName = saveLocation + "\\" + appName + ".pstl";

                WriteFileOnFileSystem(context.Request.GetBufferlessInputStream(true), fileName, appGuid);
            }
            catch (Exception ex)
            {
                //context.Trace.Write(ex.Message);
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = ex.Message;
                context.Response.End();
            }
        }

        private static void WriteFileOnFileSystem(Stream inputStream, string fileName,string guid)
        {
            byte[] encryptionKey = FileEncryptor.GenerateEncryptionKey(guid.ToLower());
            byte[] buffer = new byte[encryptionKey.Length];


            using (var outputStream = new FileStream(fileName, FileMode.Create))
            {
                var transferLength = inputStream.Length;
                var byteNo = 0L;
                while (transferLength > 0)
                {
                    //Thread.Sleep(50); // For Debug 
                    inputStream.Read(buffer, 0, buffer.Length);
                  
                    var sendLength = (int)Math.Min(transferLength, buffer.Length);

                    // encrypt
                    for (var i = 0; i < sendLength; i++)
                    {
                        buffer[i] = (byte)(buffer[i] ^ encryptionKey[byteNo % encryptionKey.Length]);
                        byteNo++;
                    }

                    outputStream.Write(buffer, 0, sendLength);
                    transferLength -= sendLength;
                }
            }
        }

        public bool IsReusable => false;
    }
}