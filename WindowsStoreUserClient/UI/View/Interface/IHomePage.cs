using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.UI.View.Interface
{
    public interface IHomePage
    {
        void ShowNetworkErrorMessage();
        void HideNetworkErrorMessage();
        void SetFlipViewHeight();
    }
}
