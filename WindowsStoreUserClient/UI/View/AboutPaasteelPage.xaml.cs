using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;


namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class AboutPaasteelPage : Page, IAboutPaasteelPage
    {
        public AboutPaasteelPageViewModel ViewModel { get; set; }
        public AboutPaasteelPage()
        {
            this.InitializeComponent();
            ViewModel = (AboutPaasteelPageViewModel)DataContext;
            ViewModel.View = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.PageTitle = "AboutPaasteel".Localize();
        }

        async Task IAboutPaasteelPage.ShowUpdateIsAvailableMessageAsync(string message)
        {
            // Show dialog
            var messageDialog = new MessageDialog(message);
            messageDialog.Commands.Add(new UICommand(
                "Yes".Localize(),
                new UICommandInvokedHandler(this.CommandInvokedHandler),
                "Yes"));
            messageDialog.Commands.Add(new UICommand(
                "No".Localize(),
                new UICommandInvokedHandler(this.CommandInvokedHandler),
                "No"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            var invokedCommand = await messageDialog.ShowAsync();

            if (((string)invokedCommand.Id) == "Yes")
            {
                await ViewModel.DownloadCurrentAppLatestVersionAsync();
            }
        }
        private void CommandInvokedHandler(IUICommand command)
        {

        }

        void IAboutPaasteelPage.ShowCheckForUpdateErrorMessage()
        {
            var messageDialog = new MessageDialog("ErrorInCheckingForUpdatesMessage".Localize());
            var task = messageDialog.ShowAsync();
        }

        public void ShowYouHaveLatestVersionMessage()
        {
            var messageDialog = new MessageDialog("YouHaveLatestPaasteelVersionMessage".Localize());
            var task = messageDialog.ShowAsync();
        }
    }
}
