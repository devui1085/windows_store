using Windows.UI.Xaml.Controls;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfirmRegistrationPage : Page
    {
        public ConfirmRegistrationPage()
        {
            this.InitializeComponent();
            var topAppBarUserControl =
              (ITopAppBarUserControlViewModel)((TopAppBarUserControl)this.TopAppBar.Content).DataContext;
            topAppBarUserControl.SignOutEnabled = true;
        }
    }
}
