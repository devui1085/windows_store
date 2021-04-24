using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Service.ApplicationService;

namespace WindowsStore.Client.User.Service.ApplicationService.Initilize
{
    public static class SignInInitializer
    {
        static SignInInitializer()
        {

        }

        public static void Initialize()
        {
            var userManager = UserManager.Instance;
            if (string.IsNullOrEmpty(userManager.StoredUserName)) return;
            var task = userManager.SignInAsync(userManager.StoredUserName, userManager.StoredPassword);
        }
    }
}
