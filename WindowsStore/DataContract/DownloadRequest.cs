using System.ServiceModel;

namespace Store.DataContract
{
    [MessageContract]
    public class DownloadRequest
    {
        [MessageBodyMember]
        public string FileName;
    }

}
