using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Microsoft.Practices.Unity;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private INavigationService _navigationService;
        private IResourceLoader _resourceLoader;
        public MainPage()
        {
            this.InitializeComponent();
            InitializeMainPage();
            ((IMainPageViewModel) this.DataContext).NavigationService = _navigationService;
            var signInViewModel = (ISignInViewModel)PrismUnityApplication.Current.Container.Resolve(typeof(ISignInViewModel));
            signInViewModel.CheckUserSavedCredential(ViewNames.SignIn);
        }

        private void InitializeMainPage()
        {
            ((App) PrismUnityApplication.Current).CreateNewNavigationFrame(ContainerFrame);

            _navigationService =
                (INavigationService) PrismUnityApplication.Current.Container.Resolve(typeof (INavigationService));
            _resourceLoader =
             (IResourceLoader)PrismUnityApplication.Current.Container.Resolve(typeof(IResourceLoader));
            ContainerFrame.Navigated += ContainerFrame_Navigated;

            // handle application navigationback button
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_navigationService.CanGoBack())
                _navigationService.GoBack();
        }

        private void ContainerFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //BackButton.Visibility = e.SourcePageType.Name == "DashboardPage" ? Visibility.Collapsed : Visibility.Visible;
            PageNameTextBlock.Text = _resourceLoader.GetString(e.SourcePageType.Name);
            if (e.SourcePageType.Name.Equals(ViewNames.Dashboard + "Page"))
            {
                ((IMainPageViewModel) this.DataContext).NotifyMainFormForNewChanges();
            }
        }

        private void HamburgerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // if (SharesListBoxItem.IsSelected)
           // {
           //     //ResutlTextBlock.Text = "Share";
           // }
           // else if (FavoritesListBoxItem.IsSelected)
           // {
           //    // ResutlTextBlock.Text = "Favorite";
           //ContainerFrame.Navigate(typeof (SignInPage));
           // }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_navigationService.CanGoBack())
                _navigationService.GoBack();
        }

        private void MenuBarTopActionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuBarTopActionListBox.SelectedIndex != -1)
                MenuBarBottomActionListBox.SelectedIndex = -1;
        }

        private void MenuBarBottomActionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MenuBarBottomActionListBox.SelectedIndex!=-1)
            MenuBarTopActionListBox.SelectedIndex = -1;
        }
    }
}
