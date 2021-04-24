using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.Admin.UI.View.Interface
{
    public interface ILoginPage
    {
        void NavigateToHomePage();
        void ShowLoginFailedMessage();
    }
}
