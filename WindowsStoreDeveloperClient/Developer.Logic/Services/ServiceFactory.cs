using System.ServiceModel;

namespace WindowsStore.Client.Developer.Logic.Services
{
   public class ServiceFactory<T> 
    {
      //  IDeveloperService _developerService;

       public T GetService()
       {
           var binding = new NetHttpBinding {MaxReceivedMessageSize =( 10 * 1024) *1024}; // 1 MB
           var channelFactory = new ChannelFactory<T>(binding,
               new EndpointAddress(Constants.DeveloperServiceAddress));
          return channelFactory.CreateChannel();
       }
    }
}
