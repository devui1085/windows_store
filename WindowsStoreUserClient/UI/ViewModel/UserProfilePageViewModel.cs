using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;
using WindowsStore.Client.User.UI.View.Interface;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class UserProfilePageViewModel : ViewModelBase
    {
        public IUserProfilePage View { get; set; }
        private RelayCommand _signOutCommand;
        public Person Person
        {
            get
            {
                return UserManager.Instance.User;
            }
        }

        public UserProfilePageViewModel()
        {
            UiManager.PageTitle = "Account".Localize();
        }

        #region Sign Out Command
        public ICommand SignOutCommand
        {
            get
            {
                if (_signOutCommand == null)
                    _signOutCommand = new RelayCommand(async (object obj) => await SignOutAsync(obj), CanSignOut);
                return _signOutCommand;
            }
        }

        private async Task SignOutAsync(object obj)
        {
            try {
                await UserManager.Instance.SignOutAsync();
                View.NavigateToCatalogPage();
            }
            catch {

            }
        }

        private bool CanSignOut(object obj)
        {
            return true;
        }
        #endregion

    }
}
