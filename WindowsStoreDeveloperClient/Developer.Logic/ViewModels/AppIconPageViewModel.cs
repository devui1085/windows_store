using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppIconPageViewModel : ViewModelBase, IAppIconPageViewModel
    {
        #region Constructor

        public AppIconPageViewModel(IAlertMessageService alertMessageService,IResourceLoader resourceLoader,INavigationService navigationService,IClientDeveloperService developerService)
        {
            _navigationService = navigationService;
            _developerService = developerService;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;

            SaveIconCommand = DelegateCommand.FromAsyncHandler(SaveIconAsync);
        }

        #endregion

        #region Services

        private IAppService _appService;
        private readonly INavigationService _navigationService;
        private readonly IClientDeveloperService _developerService;
        private readonly IResourceLoader _resourceLoader;
        private readonly IAlertMessageService _alertMessageService;

        #endregion

        #region Fields


        private AppDetail _appDetail;


        #endregion

        #region Properties    

        [RestorableState]
        public AppDetail AppDetail
        {
            get { return _appDetail; }
            set { SetProperty(ref _appDetail, value); }
        }



        #endregion

        #region Methods

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null)
            {
                base.OnNavigatedTo(e, viewModelState);
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                var param = e.Parameter as AppDetail;

                if (param != null)
                {
                    AppDetail = param;
                    AppDetail.AppIcon = AppDetail.AppIcon ?? new AppIcon();
                    AppDetail.AppIcon.AppId = AppDetail.AppSpecification.AppId;
                }
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState,
            bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                //AddEntityStateValue("errorsCollection", this.AppSpecification.GetAllErrors(), viewModelState);
            }
        }


        public void ShowImageSizeError()
        {
            _alertMessageService.ShowAsync(_resourceLoader.GetString("ImageSizeError"), null,
                DialogCommands.CloseDialogCommand);
        }
        #endregion

        #region Commands
        public DelegateCommand SaveIconCommand { get; }

        #endregion

        #region Actions

        private async Task SaveIconAsync()
        {
            await _developerService.RegisterAppIconAsync(AppDetail.AppIcon);

            var appDetail = await _developerService.GetDeveloperAppDetailAsync(AppDetail.AppSpecification.AppId);
            _navigationService.Navigate(ViewNames.AppDetail, appDetail);
        }

        #endregion
    }
}
