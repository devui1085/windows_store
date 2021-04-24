using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class SignUpPageViewModel : ViewModelBase
    {
        public UserManager UserManager { get; set; }
        public ISignUpPage View { get; set; }
        public NaturalPerson NaturalPerson { get; set; }

        public SignUpPageViewModel()
        {
            NaturalPerson = new NaturalPerson();
        }

        public async Task RegisterUserAsync()
        {
            try {
                var IsEmailAvailable = await UserManager.Instance.IsEmailAvailableForRegistration(NaturalPerson.PrimaryEmail);
                if (!IsEmailAvailable) {
                    await View.ShowEmailIsNotAvailableMessageAsync();
                    return;
                }
                await UserManager.Instance.RegisterNaturalPersonAsync(NaturalPerson);
                await UserManager.Instance.SignInAsync(NaturalPerson.PrimaryEmail, NaturalPerson.Password);
                View.NavigateToActivationPage();
            }
            catch (Exception exp) {
                await View.ShowErrorMessageAsync();
            }
        }
    }
}
