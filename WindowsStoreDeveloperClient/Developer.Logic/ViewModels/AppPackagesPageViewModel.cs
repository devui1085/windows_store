using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppPackagesPageViewModel :ViewModelBase , IAppPackagesViewModel
    {
        #region Constructor

        public AppPackagesPageViewModel()
        {
        }

        #endregion

        #region Services

        #endregion

        #region Fields


        private AppDetail _appDetail;

        //private AppPackageSpecification _appPackagesSpecification;
        #endregion

        #region Properties    

        [RestorableState]
        public AppDetail AppDetail
        {
            get { return _appDetail; }
            set { SetProperty(ref _appDetail, value); }
        }

        //[RestorableState]
        //public AppPackageSpecification AppPackageSpecification
        //{
        //    get { return _appPackagesSpecification; }
        //    set { SetProperty(ref _appPackagesSpecification, value); }
        //}

        [RestorableState]
        public bool SelectX64PackageEnabled => !AppPackageSpecification.HasX64Package;

        [RestorableState]
        public bool SelectX86PackageEnabled => !AppPackageSpecification.HasX86Package;

        [RestorableState]
        public bool SelectArmPackageEnabled => !AppPackageSpecification.HasArmPackage;

       
        #endregion

        #region Methods

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
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

                    AppPackageSpecification = AppDetail.AppPackageSpecification ?? new AppPackageSpecification();
                }
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                //AddEntityStateValue("errorsCollection", this.AppSpecification.GetAllErrors(), viewModelState);
            }
        }
        #endregion

        #region Commands
        public DelegateCommand DeleteX64AppPackageCommand { get; }
        public DelegateCommand DeleteX86AppPackageCommand { get; }
        public DelegateCommand DeleteArmAppPackageCommand { get; }
        #endregion

        #region Actions

        public async Task DeleteX64AppPackageCommandAsync()
        {
            
        }

        public bool CanDeleteX64AppPackage()
        {
            return AppPackageSpecification.HasX64Package;
        }


        public async Task DeleteX32AppPackageCommandAsync()
        {
        }

        public bool CanDeleteX32AppPackage()
        {
            return AppPackageSpecification.HasX86Package;
        }

        public async Task DeleteArmAppPackageCommandAsync()
        {
        //    return HasArmPackage;
        }

        public bool CanDeleteArmAppPackage()
        {
            return AppPackageSpecification.HasArmPackage;
        }
        #endregion
    }
}
