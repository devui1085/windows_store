using System;
using System.ServiceModel;
using StoreClient.DeveloperService;
using System.IO;
using Store.Common.ExtensionMethod;
using Store.Common.Enum;
using System.Data.Entity;
using Store.DataAccess.Context;
using System.Linq;
using Store.DomainModel.Entity;

namespace StoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsStoreContext context = new WindowsStoreContext();
            var apps = context.Apps.Where(app => app.Guid != Guid.Empty);

            foreach (var app in apps) {
                var thumbnailPath = $"C:\\Paasteel\\Apps\\{app.Guid}\\Screenshots\\Thumbnail";
                var thumbnails = Directory.EnumerateFiles(thumbnailPath);

                thumbnails.ForEach(thumb =>
                {
                    app.Screenshots.Add(new Screenshot()
                    {
                        AppId = app.Id,
                        FileName = Path.GetFileName(thumb),
                        Type = ScreenshotType.Mobile
                    });
                });

            }
            context.SaveChanges();



            //bool b=   TestCall();
            //System.ServiceModel.NetHttpBinding biding = new NetHttpBinding();
            //EndpointAddress endPoint = new EndpointAddress("http://localhost:1578/Service/DeveloperService.svc/~/Service/Developer.svc");
            //DeveloperService.DeveloperServiceClient proxy2 = new DeveloperService.DeveloperServiceClient(biding, endPoint);

            //try
            //{
            //    proxy2.SignIn("", "");

            //}
            //catch (FaultException<GeneralInternalFault> x)
            //{

            //    Console.WriteLine(x.Detail.FaultCode);
            //}
            //catch (FaultException)
            //{

            //}



            //AppsService.AppsServiceClient appClient = new AppsService.AppsServiceClient("BasicHttpBinding_IAppsService");
            //Console.WriteLine(appClient.GetServiceName());
            //appClient.Close();

            //Console.ReadLine();
            //1
            //  createProxyAndReadData_1();

            //2
            //readServiceNameAsynk_2();
            //Console.WriteLine("get service name called asycronoslly...");
            //Console.ReadLine();

            //3
            //

        }

        //  static bool  TestCall()
        //  {
        //      string serviceUrl = "http://localhost:1578/Service/DeveloperService.svc/~/Service/Developer.svc";
        //      ChannelFactory<IDeveloperService> factory;

        //      NetHttpBinding binding = new NetHttpBinding();
        //     // binding.WebSocketSettings.TransportUsage = System.ServiceModel.Channels.WebSocketTransportUsage.Always;
        //      factory = new ChannelFactory<IDeveloperService>(binding, new EndpointAddress(serviceUrl));

        //      string x = string.Empty;
        //      IDeveloperService proxy = factory.CreateChannel();
        //      using (new OperationContextScope((IContextChannel)proxy))
        //      {
        //          proxy.SetSession("mu");

        //          x = proxy.GetName(5);
        //      }

        //      ((IClientChannel)proxy).Close();
        //      return x == "5";
        //  }
        //  private static void Download(FileTransferService.FileTransferServiceClient client)
        //  {

        //      try
        //      {
        //          // start service client


        //          // kill target file, if already exists
        //          string filePath = System.IO.Path.Combine("Download", "123.mp4");
        //          if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

        //          // get stream from server
        //          System.IO.Stream inputStream;
        //          string fileName = "123.mp4";
        //          long length = client.DownloadFile(ref fileName, out inputStream);

        //          // write server stream to disk
        //          using (System.IO.FileStream writeStream = new System.IO.FileStream(filePath, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write))
        //          {
        //              int chunkSize = 2048;
        //              byte[] buffer = new byte[chunkSize];

        //              do
        //              {
        //                  // read bytes from input stream
        //                  int bytesRead = inputStream.Read(buffer, 0, chunkSize);
        //                  if (bytesRead == 0) break;

        //                  // write bytes to output stream
        //                  writeStream.Write(buffer, 0, bytesRead);

        //                  // report progress from time to time
        //                  Console.WriteLine((int)(writeStream.Position * 100 / length));
        //              } while (true);



        //              writeStream.Close();
        //          }

        //          // close service client
        //          inputStream.Dispose();
        //       //   client.Close();
        //      }
        //      catch (Exception)
        //      {

        //      }
        //      finally
        //      {
        //      //    client.Close();
        //      }
        //  }

        //  private static void Upload(FileTransferService.FileTransferServiceClient client)
        //  {
        //      try
        //      {
        //          string fileName = "f:\\xxx.mp4";
        //          // get some info about the input file
        //          System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);



        //          // open input stream
        //          using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        //          {
        //              using (StreamWithProgress uploadStreamWithProgress = new StreamWithProgress(stream))
        //              {
        //                  uploadStreamWithProgress.ProgressChanged += uploadStreamWithProgress_ProgressChanged;

        //                  // start service client

        //                  // upload file
        //                  client.UploadFile(fileInfo.Name, fileInfo.Length, uploadStreamWithProgress);


        //                  // close service client
        //                  client.Close();
        //              }
        //          }
        //      }
        //      catch (Exception)
        //      {

        //      }
        //      finally
        //      {

        //      }
        //  }


        //static  void  uploadStreamWithProgress_ProgressChanged(object sender, StreamWithProgress.ProgressChangedEventArgs e)
        //  {
        //      if (e.Length != 0)
        //          Console.WriteLine((int)(e.BytesRead * 100 / e.Length));
        //  }
        //  //private static void createProxyAndReadData_1()
        //  //{
        //  //    // Create a proxy object and connect to the service
        //  //    AppsServiceClient proxy = new AppsServiceClient();

        //  //    Console.WriteLine(proxy.GetServiceName());

        //  //    // close proxy to release resources
        //  //    proxy.Close();
        //  //    Console.WriteLine("Press ENTER to finish");

        //  //    Console.ReadLine();

        //  //    //  حتما بعد از استفاده از پراکسی برای آزاد شدن منابع پراکسی را ببندید
        //  //    // یا می توانید از بلاک یوزینگ استفاده کنید
        //  //    // Create a proxy object and connect to the service
        //  //    using (AppsServiceClient autoCloseProxy = new AppsServiceClient())
        //  //    {
        //  //        // Use the proxy     ...      

        //  //    } // Disconnect and close the proxy automatically

        //  //}

        //  //private static async void readServiceNameAsynk_2()
        //  //{
        //  //        using (AppsServiceClient proxy = new AppsServiceClient())
        //  //        {
        //  //            string ServiceName = await proxy.GetServiceNameAsync();

        //  //            Console.WriteLine("servicName is " + ServiceName);
        //  //        }
        //  //}
    }
}
