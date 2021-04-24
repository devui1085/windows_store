using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.View;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.Infrastructure
{
    public class UiManager
    {
        static UiManager _instance;
        MainPageViewModel _mainPageViewModel;
        bool _maximizeSubFrame;
        public event EventHandler ModalMessageFirstActionClicked;

        private UiManager()
        {
        }

        public static UiManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UiManager();
                return _instance;
            }
        }

        public void Initialize(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        private void _mainPageViewModel_ModalMessageFirstActionClicked(object sender, EventArgs e)
        {
            if (ModalMessageFirstActionClicked != null)
                ModalMessageFirstActionClicked(sender, e);
        }

        public string PageTitle
        {
            set
            {
                _mainPageViewModel.PageTitle = value;
            }
            get
            {
                return _mainPageViewModel.PageTitle;
            }
        }

        public void ShowLoading()
        {
            _mainPageViewModel.View.ShowLoading();
        }

        public void HideLoading()
        {
            _mainPageViewModel.View.HideLoading();
        }

        public async Task ShowMessageAsync(string message, string title)
        {
            MessageDialog dlg = new MessageDialog(message, title);
            dlg.Commands.Add(new UICommand("Ok".Localize()));
            await dlg.ShowAsync();
        }

        public async Task ShowMessageAsync(string message)
        {
            MessageDialog dlg = new MessageDialog(message);
            dlg.Commands.Add(new UICommand("Ok".Localize()));
            await dlg.ShowAsync();
        }

        public bool IsSubFrameMaximized
        {
            set
            {
                var rootFrame = Window.Current.Content as Frame;
                var mainPage = rootFrame.Content as Page;
                VisualStateManager.GoToState(mainPage, value ? "MaximizeSubFrameVisualState" : "DefaultVisualState", false);
                _maximizeSubFrame = value;
            }

            get
            {
                return _maximizeSubFrame;
            }
        }

        public bool AreMainPageInteractiveControlsEnabled
        {
            get
            {
                return _mainPageViewModel.AreInteractiveControlsEnabled;
            }

            set
            {
                _mainPageViewModel.AreInteractiveControlsEnabled = value;
            }
        }

        public void ShowModalMessage(string message, string firstActionText, EventHandler firstActionClickEventHandler)
        {
            _mainPageViewModel.ShowModalMessage(message, firstActionText, firstActionClickEventHandler);
        }

        public void HideModalMessage()
        {
            _mainPageViewModel.HideModalMessage();
        }
    }
}
