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
using Prism.Unity.Windows;
using Prism.Windows.Navigation;
using Microsoft.Practices.Unity;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardPage : Page
    {
        private INavigationService _navigationService;
        public DashboardPage()
        {
            this.InitializeComponent();
            _navigationService =
                (INavigationService) PrismUnityApplication.Current.Container.Resolve(typeof (INavigationService));
        }

        private void PivotItem_Loaded(object sender, RoutedEventArgs e)
        {
            MyAppListFrame.Navigate(typeof (AppListPage));
        }
    }
}
