using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Model.Security;
using WindowsStore.Client.Admin.RemoteService.Service;
using WindowsStore.Client.Admin.UI.View.Interface;

namespace WindowsStore.Client.Admin.UI.ViewModel
{
    public class LoginPageViewModel
    {
        public ILoginPage View { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
        public async Task LoginAsync()
        {
            AuthenticationResult = await UserManagementService.Instance.SignInAsync(Email, Password);
            if (AuthenticationResult.Authenticated)
            {
                View.NavigateToHomePage();
            }
            else
            {
                View.ShowLoginFailedMessage();
            }
        }
    }
}
