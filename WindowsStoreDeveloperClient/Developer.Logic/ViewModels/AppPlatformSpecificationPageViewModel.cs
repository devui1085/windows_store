using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Linq;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppPlatformSpecificationPageViewModel:ViewModelBase, IAppPlatformSpecificationPageViewModel
    {
        #region Constructor

        public AppPlatformSpecificationPageViewModel(IAlertMessageService alertMessageService, IResourceLoader resourceLoader, INavigationService navigationService, IClientDeveloperService developerService)
        {
            _navigationService = navigationService;
            _developerService = developerService;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;
           
            _platformDictionary = new Dictionary<string, int>();
            SavePalatformSpecificationCommand = DelegateCommand.FromAsyncHandler(SavePlatformSpecificationAsync);
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
        
        private readonly Dictionary<string, int> _platformDictionary;

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
                    AppDetail.AppPlatformSpecification.CpuArchitectureFlags =
                        AppDetail.AppPlatformSpecification.CpuArchitectureFlags ?? DeveloperService.CpuArchitecture.None;
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

        public void AddPlatformToDectionary(string key, int value)
        {
            _platformDictionary.Add(key, value);
        }

        public void RemovePlatformFromDictionary(string key)
        {
            _platformDictionary.Remove(key);
        }

        public void AddCpuArchitecture(CpuArchitecture cpuArchitecture)
        {
            AppDetail.AppPlatformSpecification.CpuArchitectureFlags |= cpuArchitecture;
        }

        public void RemoveCpuArchitecture(CpuArchitecture cpuArchitecture)
        {
            AppDetail.AppPlatformSpecification.CpuArchitectureFlags &= ~cpuArchitecture;
        }

        #endregion

        #region Commands

        public DelegateCommand SavePalatformSpecificationCommand { get; }

        #endregion

        #region Actions

        private async Task SavePlatformSpecificationAsync()
        {
            if (AppDetail.AppPlatformSpecification.CpuArchitectureFlags == CpuArchitecture.None)
            {
                await _alertMessageService.ShowAsync(_resourceLoader.GetString("CpuArchitectureIsNotSelected"), null, DialogCommands.CloseDialogCommand);
                return;
            }

            if (_platformDictionary.Count == 0)
            {
                await _alertMessageService.ShowAsync(_resourceLoader.GetString("DeviceFamilyIsNotSelected"), null, DialogCommands.CloseDialogCommand);
                return;
            }

            var platformCategories=new int[_platformDictionary.Values.Count];
            _platformDictionary.Values.CopyTo(platformCategories,0);

            AppDetail.AppPlatformSpecification.PlatformCategories = platformCategories.Any(a => a == 1)
                ? new int[] {1}
                : platformCategories;

         await _developerService.RegisterAppPlatformSpecificationAsync(AppDetail.AppPlatformSpecification);
            _navigationService.Navigate(ViewNames.AppDetail, AppDetail);
        }



        #endregion



    }
}
