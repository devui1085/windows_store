using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class UserProfilePage : Page, IUserProfilePage
    {
        public UserProfilePageViewModel ViewModel { get; set; }
        public string UserName { get; set; }
        public string FullName
        {
            get
            {
                var person = UserManager.Instance.User;
                var fullname = person is NaturalPerson ?
                    (person as NaturalPerson).FullName :
                    (person as LegalPerson).Name;
                return fullname;
            }
        }

        public UserProfilePage()
        {
            this.InitializeComponent();
            ViewModel = (UserProfilePageViewModel)DataContext;
            ViewModel.View = this;
        }

        void IUserProfilePage.NavigateToCatalogPage()
        {
            Frame.Navigate(typeof(CatalogPage));
            Frame.BackStack.RemoveAt(Frame.BackStack.Count - 1);
        }
    }
}
