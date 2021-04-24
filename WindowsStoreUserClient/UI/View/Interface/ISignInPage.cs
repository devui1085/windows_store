using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.UI.View.Interface
{
    public interface ISignInPage
    {
        void ShowWaiting(bool show);
        Task ShowInvalidCredentialsMessageAsync();
        void NavigateToCatalogPage();
    }
}
