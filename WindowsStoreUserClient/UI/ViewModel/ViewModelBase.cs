using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class ViewModelBase : BindableBase
    {
        public App CurrentApp
        {
            get
            {
                return App.Current as App;
            }
        }

        public UiManager UiManager
        {
            get
            {
                return UiManager.Instance;
            }
        }
    }
}
