using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Remote.Wcf;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public class UserManager
    {
        static UserManager _instance;
        Remote.Wcf.UserService _userService;

        #region Delegates
        public delegate void SignInOperationCompletedEventHandler();
        #endregion

        #region Events
        public event SignInOperationCompletedEventHandler SignInOperationCompleted;
        public event Action SignedOutOperationCompleted;
        #endregion

        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserManager();
                return _instance;
            }
        }

        public bool IsSignedIn { set; get; }
        public bool IsProfileActivated { get; set; }
        public Person User { get; set; }

        public string StoredUserName
        {
            get
            {
                return LocalSettings.Get(LocalSettingKeys.UserName) as string;
            }
            set
            {
                LocalSettings.Set(LocalSettingKeys.UserName, value);
            }
        }

        public string StoredPassword
        {
            get
            {
                return LocalSettings.Get(LocalSettingKeys.UserPassword) as string;
            }
            set
            {
                LocalSettings.Set(LocalSettingKeys.UserPassword, value);
            }
        }

        public UserManager()
        {
            _userService = new Remote.Wcf.UserService();
        }

        public async Task<bool> IsEmailAvailableForRegistration(string email)
        {
            return await _userService.IsEmailAvailableForRegistration(email);
        }

        public async Task RegisterNaturalPersonAsync(NaturalPerson naturalPerson)
        {
            await _userService.RegisterNaturalPersonAsync(naturalPerson);
        }

        public async Task SignInAsync(string username, string password)
        {
            AuthenticationResult result = await _userService.SignInAsync(username, password);
            IsSignedIn = result.Authenticated;
            User = IsSignedIn ? result.Person : null;
            IsProfileActivated = IsSignedIn ? result.UserAccountStatus == UserAccountStatus.Activated : false;
            StoredUserName = IsSignedIn ? username : null;
            StoredPassword = IsSignedIn ? password : null;

            // Raise events
            if (SignInOperationCompleted != null)
                SignInOperationCompleted();
        }

        public async Task SignOutAsync()
        {
            await _userService.SignOutAsync();
            User = null;
            StoredUserName = null;
            StoredPassword = null;
            IsProfileActivated = false;
            IsSignedIn = false;
            if (SignedOutOperationCompleted != null)
                SignedOutOperationCompleted();
        }

        public async Task<bool> TryActivateAccountAsync(int activationCode)
        {
            IsProfileActivated = await _userService.TryActivateAccountAsync(activationCode);
            return IsProfileActivated;
        }

        public async Task ResendActivationCode()
        {
            await _userService.ResendActivationCodeAsync();
        }
    }
}
