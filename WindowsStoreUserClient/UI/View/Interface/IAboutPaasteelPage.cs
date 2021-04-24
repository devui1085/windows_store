using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.UI.View.Interface
{
    public interface IAboutPaasteelPage
    {
        Task ShowUpdateIsAvailableMessageAsync(string message);
        void ShowCheckForUpdateErrorMessage();
        void ShowYouHaveLatestVersionMessage();

    }
}
