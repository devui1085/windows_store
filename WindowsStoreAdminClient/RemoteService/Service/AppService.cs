using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.RemoteService.ModelMapping;

namespace WindowsStore.Client.Admin.RemoteService.Service
{
    public class AppService : RemoteServiceBase
    {
        static AppService _instance;

        public static AppService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppService();
                return _instance;
            }
        }

        private AppService()
        {
        }
    }
}
