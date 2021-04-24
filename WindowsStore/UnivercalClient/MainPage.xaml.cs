using App1.DeveloperService;
using App1.FileTransferService;
using StoreClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string serviceUrl = "http://localhost:1578/Service/DeveloperService.svc/~/Service/Developer.svc";
        const string fileTrasnferServicUrl= "http://localhost:1578/Service/FileTransferService.svc/~/Service/FileTransferService.svc";
        ChannelFactory<IDeveloperService> factory;
        ChannelFactory<IFileTransferService> fileTransferServiceFactory;

        public MainPage()
        {
            this.InitializeComponent();

            factory = CreateFactory();
            fileTransferServiceFactory = CreateFileTransferServiceFactory();
            SetSessions();
        }

        ChannelFactory<IDeveloperService> CreateFactory()
        {
            NetHttpBinding binding = new NetHttpBinding();
          //  binding.Security.Mode = BasicHttpSecurityMode.None;
            return new ChannelFactory<IDeveloperService>(binding, new EndpointAddress(serviceUrl));
        }

        ChannelFactory<IFileTransferService> CreateFileTransferServiceFactory()
        {
            NetHttpBinding binding = new NetHttpBinding();
            //  binding.Security.Mode = BasicHttpSecurityMode.None;
            return new ChannelFactory<IFileTransferService>(binding, new EndpointAddress(fileTrasnferServicUrl));
        }

        async void SetSessions()
        {
            IDeveloperService proxy = factory.CreateChannel();
         
            try
            {
                await proxy.SetRealSessionAsync("kos baghali");
                await proxy.SetSessionAsync("kos choghandar");
            }
            catch (FaultException<SessionFault> sf)
            {
                string message = sf.Detail.SessionMessage;
                string opertaion = sf.Detail.SessionOperation;
                string reson = sf.Detail.SessionReason;
            }
            ((IClientChannel)proxy).Close();
        }

        async void ReadSessions()
        {
            IDeveloperService proxy = factory.CreateChannel();

            string x = await proxy.GetSessionAsync();
            string y = await proxy.GetRealSessionAsync();

            ((IClientChannel)proxy).Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ReadSessions();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {

       
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
         //   Download();
        }

        async void Upload()
        {
            IFileTransferService proxy = fileTransferServiceFactory.CreateChannel();

            try
            {
                string fileName = "f:\\xxx.mp4";
                // get some info about the input file
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);



                // open input stream
                using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (StreamWithProgress uploadStreamWithProgress = new StreamWithProgress(stream))
                    {
                        uploadStreamWithProgress.ProgressChanged += uploadStreamWithProgress_ProgressChanged;

                        // start service client

                        // upload file
                        proxy.UploadFileAsync(fileInfo.Name, fileInfo.Length, uploadStreamWithProgress);


                        // close service client

                    }
                }
            }
            catch (FaultException<SessionFault> sf)
            {
                string message = sf.Detail.SessionMessage;
                string opertaion = sf.Detail.SessionOperation;
                string reson = sf.Detail.SessionReason;
            }
            ((IClientChannel)proxy).Close();
        }

        static void uploadStreamWithProgress_ProgressChanged(object sender, StreamWithProgress.ProgressChangedEventArgs e)
        {
            string output = string.Empty;
            if (e.Length != 0)
               output =((int)(e.BytesRead * 100 / e.Length)).ToString();
        }
    }
}
