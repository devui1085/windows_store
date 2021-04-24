using System;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;
using UserChangedEventArgs = WindowsStore.Client.Developer.Logic.Models.UserChangedEventArgs;
using User = WindowsStore.Client.Developer.Logic.Models.User;

namespace WindowsStore.Client.Developer.Logic.ServiceInterface
{
    public interface IAccountService
    {
        event EventHandler<UserChangedEventArgs> UserChanged;
        UserInfo SignedInUser { get; }
        Task<UserInfo> VerifyUserAuthenticationAsync();
        Task<UserInfo> VerifySavedCredentialsAsync();
        Task<LogOnResult> SignInUserAsync(string userName, string password, bool useCredentialStore);    
        void SignOut();
        Task SignUp(User user);
        Task<LogOnResult> TrySignInOnSavedCredentialsAsync();
    }
}
