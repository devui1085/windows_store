using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.UI.View.Interface
{
    public interface IMainPage
    {
        void ShowLoading();
        void HideLoading();
        void ShowSignInButton(string content);

        Task NavigateToDownloadsPageForMandatoryUpdateAsync();
        void NavigateToHomePage();
        bool AreInteractiveControlsEnabled { set; get; }

        void ShowModalMessage(string message, string firstActionText, EventHandler firstActionClickEventHandler);
        void HideModalMessage();
    }
}
