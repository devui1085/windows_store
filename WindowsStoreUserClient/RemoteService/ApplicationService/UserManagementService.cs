using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Model;
using System.ServiceModel.Channels;
using System.ServiceModel;
using WindowsStore.Client.User.RemoteService.ModelMapping;
using WindowsStore.Client.User.Common.Model.Security;

namespace WindowsStore.Client.User.RemoteService.Service
{
    public class UserManagementService : ServiceBase
    {
        static UserManagementService _instance;

        private UserManagementService()
        {
        }

        public static UserManagementService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserManagementService();
                return _instance;
            }
        }
    }
}
