using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.Models;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class DashboardAppItemUserControlViewModel:ViewModelBase
    {
        #region Constructor

        public DashboardAppItemUserControlViewModel(INavigationService navigationService,IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;
            _resourceLoader = resourceLoader;

            GoToAppDetailPageCommand = new DelegateCommand(GoToEditAppDetailPage);
            GoToDeleteAppPageCommand = new DelegateCommand(GoToDeleteAppPage);
        }
        #endregion

        #region Services

        private readonly INavigationService _navigationService;
        private readonly IResourceLoader _resourceLoader;

        #endregion

        #region Fields
        #endregion

        #region Properties   
        [RestorableState]
        public AppDetail AppDetail{ get; set; }

        [RestorableState]
        public string AppStateTitle => _resourceLoader.GetString(AppDetail.AppSpecification.State.ToString());
        #endregion

        #region Methods

        #endregion

        #region Commands
        public DelegateCommand GoToAppDetailPageCommand { get; }
        public DelegateCommand GoToDeleteAppPageCommand { get; }

        #endregion

        #region Actions

        public void GoToEditAppDetailPage()
        {
            _navigationService.Navigate(ViewNames.AppDetail,AppDetail);
        }

        public void GoToDeleteAppPage()
        {
            _navigationService.Navigate(ViewNames.DeleteApp, AppDetail);
        }

        #endregion
    }

}
