using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.Admin.UI.View.Interface;
using WindowsStore.Client.Admin.UI.ViewModel;

namespace WindowsStore.Client.Admin.UI.View
{
    public sealed partial class UserManagementPage : Page, IUserManagementPage
    {
        public UserManagementPageViewModel ViewModel{ get; set; }
        public UserManagementPage()
        {
            this.InitializeComponent();
            ViewModel = (UserManagementPageViewModel)DataContext;
            ViewModel.View = this;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadUsersAsync();
        }

        private async void deletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (pivot.SelectedIndex == 0 && naturalPersonListView.SelectedItem != null)
                await ViewModel.DeleteSelectedNaturalPerson();
            if (pivot.SelectedIndex == 1 && legalPersonListView.SelectedItem != null)
                await ViewModel.DeleteSelectedLegalPerson();
        }
    }
}
