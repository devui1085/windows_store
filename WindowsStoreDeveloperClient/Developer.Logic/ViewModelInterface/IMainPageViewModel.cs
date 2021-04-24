using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface IMainPageViewModel
    {
        INavigationService NavigationService { set; }
        void NotifyMainFormForNewChanges();
    }
}
