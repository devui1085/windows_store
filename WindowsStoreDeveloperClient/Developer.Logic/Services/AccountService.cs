using System;
using System.Security;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Windows.AppModel;
using User = WindowsStore.Client.Developer.Logic.Models.User;
using UserChangedEventArgs = WindowsStore.Client.Developer.Logic.Models.UserChangedEventArgs;

namespace WindowsStore.Client.Developer.Logic.Services
{
    public class AccountService : IAccountService
    {
        public const string SignedInUserKey = "AccountService_SignedInUser";
        public const string PasswordVaultResourceName = "PassteelDeveloperApp";
        private const string UserNameKey = "AccountService_UserName";
        private const string PasswordKey = "AccountService_Password";
        private readonly IClientDeveloperService _developerService;
        private readonly ISessionStateService _sessionStateService;
        private readonly ICredentialStore _credentialStore;
        private string _userName;
        private string _password;

        public AccountService(ISessionStateService sessionStateService, ICredentialStore credentialStore, IClientDeveloperService developerService)
        {
            //_developerService = new ServiceFactory<IDeveloperService>().GetService();
            _sessionStateService = sessionStateService;
            _credentialStore = credentialStore;
            _developerService = developerService;

            if (_sessionStateService != null)
            {
                if (_sessionStateService.SessionState.ContainsKey(SignedInUserKey))
                {
                    SignedInUser = _sessionStateService.SessionState[SignedInUserKey] as UserInfo;
                }

                if (_sessionStateService.SessionState.ContainsKey(UserNameKey))
                {
                    _userName = _sessionStateService.SessionState[UserNameKey].ToString();
                }

                if (_sessionStateService.SessionState.ContainsKey(PasswordKey))
                {
                    _password = _sessionStateService.SessionState[PasswordKey].ToString();
                }
            }
        }

        public event EventHandler<UserChangedEventArgs> UserChanged;

        public UserInfo SignedInUser { get; private set; }

        /// <summary>
        /// Gets the current active user signed in the app.
        /// </summary>
        /// <returns>A Task that, when complete, retrieves an active user that is ready to be used for any operation against the service.</returns>
        public async Task<UserInfo> VerifyUserAuthenticationAsync()
        {
            try
            {
                // If user is logged in, verify that the session in the service is still active
                if (SignedInUser != null && await _developerService.VerifyActiveSessionAsync(SignedInUser.PrimaryEmail))
                {
                    return SignedInUser;
                }
            }
            catch (SecurityException)
            {
                // User's session has expired.
            }

            // Attempt to sign in using credentials stored in session state
            // If succeeds, ask for a new active session
            if (_userName != null && _password != null)
            {
                var result = await SignInUserAsync(_userName, _password, false);
                if (result.SignedIn)
                {
                    return SignedInUser;
                }
            }

            return await VerifySavedCredentialsAsync();
        }

        public async Task<UserInfo> VerifySavedCredentialsAsync()
        {
            // Attempt to sign in using credentials stored locally
            // If succeeds, ask for a new active session
            var savedCredentials = _credentialStore.GetSavedCredentials(PasswordVaultResourceName);
            if (savedCredentials != null)
            {
                savedCredentials.RetrievePassword();
                var result = await SignInUserAsync(savedCredentials.UserName, savedCredentials.Password, false);
                if (result.SignedIn)
                {
                    return SignedInUser;
                }
            }

            return null;
        }

        public async Task<LogOnResult> TrySignInOnSavedCredentialsAsync()
        {
            // Attempt to sign in using credentials stored locally
            // If succeeds, ask for a new active session
            var savedCredentials = _credentialStore.GetSavedCredentials(PasswordVaultResourceName);
            if (savedCredentials != null)
            {
                savedCredentials.RetrievePassword();
                var result = await SignInUserAsync(savedCredentials.UserName, savedCredentials.Password, false);
                if (result.SignedIn)
                {
                    return result;
                }
            }

            return null;
        }

        public async Task<LogOnResult> SignInUserAsync(string userName, string password, bool useCredentialStore)
        {
            var result = await _developerService.SignInAsync(userName, password);

            if (!result.SignedIn) return result;

            var previousUser = SignedInUser;
            SignedInUser = result.UserInfo;

            // Save SignedInUser in the StateService
            _sessionStateService.SessionState[SignedInUserKey] = SignedInUser;

            // Save username and password in state service
            _userName = userName;
            _password = password;
            _sessionStateService.SessionState[UserNameKey] = userName;
            _sessionStateService.SessionState[PasswordKey] = password;
            if (useCredentialStore)
            {
                // Save credentials in the CredentialStore
                _credentialStore.SaveCredentials(PasswordVaultResourceName, userName, password);
            }

            if (previousUser == null)
            {
                // Raise use changed event if user logged in
                RaiseUserChanged(SignedInUser, previousUser);
            }
            else if (SignedInUser != null && SignedInUser.PrimaryEmail != previousUser.PrimaryEmail)
            {
                // Raise use changed event if user changed
                RaiseUserChanged(SignedInUser, previousUser);
            }

            return result;
        }

        public void SignOut()
        {
            var previousUser = SignedInUser;
            SignedInUser = null;
            _userName = null;
            _password = null;

            _sessionStateService.SessionState.Remove(SignedInUserKey);
            _sessionStateService.SessionState.Remove(UserNameKey);
            _sessionStateService.SessionState.Remove(PasswordKey);

            // remove user from the CredentialStore, if any
            _credentialStore.RemoveSavedCredentials(PasswordVaultResourceName);

            RaiseUserChanged(SignedInUser, previousUser);
        }

        public Task SignUp(User user)
        {
            //   _developerService.RegisterNaturalPersonAsync()
            return null;
        }


        private void RaiseUserChanged(UserInfo newUserInfo, UserInfo oldUserInfo)
        {
            var handler = UserChanged;
            handler?.Invoke(this, new UserChangedEventArgs(newUserInfo, oldUserInfo));
        }
    }
}
