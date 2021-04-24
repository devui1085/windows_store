using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppSpecificationPageViewModel :ViewModelBase
    {
        #region Constructor

        public AppSpecificationPageViewModel(INavigationService navigationService,IAppService appService,IClientDeveloperService developerService,IResourceLoader resourceLoader )
        {
            _appService = appService;
            _navigationService = navigationService;
            _developerService = developerService;
            _resourceLoader = resourceLoader;

            SaveAppSpecificationCommand = new DelegateCommand(SaveAppSpecificationAsync);
        }
        #endregion

        #region Services
        private IAppService _appService;
        private readonly INavigationService _navigationService;
        private readonly IClientDeveloperService _developerService;
        private readonly IResourceLoader _resourceLoader;
        #endregion

        #region Fields

        private bool _appTypeIsSelected;
        private IReadOnlyCollection<ComboBoxItemValue> _categories;
        private IReadOnlyCollection<ComboBoxItemValue> _prices;
        private IReadOnlyCollection<ComboBoxItemValue> _appTypes;

        private AppDetail _appDetail;
        private AppSpecification _appSpecification;

        #endregion

        #region Properties    

        [RestorableState]
        public AppDetail AppDetail
        {
            get { return _appDetail; }
            set { SetProperty(ref _appDetail, value); }
        }

        [RestorableState]
        public AppSpecification AppSpecification
        {
            get { return _appSpecification; }
            set { SetProperty(ref _appSpecification, value); }
        }

        [RestorableState]
        public int AppTypeValue
        {
            get { return (int)AppSpecification.AppType; }
            set
            {
                AppSpecification.AppType = (AppType) value;
                PopulateCategoriesAsync();
                AppTypeIsSelected = AppSpecification.AppType != AppType.None;
            }
        }

        public string AppName
        {
            get { return AppSpecification.Name; }
            set
            {
                AppSpecification.Name = value.Trim();
                CheckAppNameIsAvailable(AppSpecification.Name);
            }
        }

        [RestorableState]
        public bool AppTypeIsSelected
        {
            get { return _appTypeIsSelected; }
            set { SetProperty(ref _appTypeIsSelected, value); }
        }

        public IReadOnlyCollection<ComboBoxItemValue> AppTypes
        {
            get { return _appTypes; }
            private set { SetProperty(ref _appTypes, value); }
        }

        public IReadOnlyCollection<ComboBoxItemValue> Categories
        {
            get { return _categories; }
            private set {  SetProperty(ref _categories, value); }
        }

        public IReadOnlyCollection<ComboBoxItemValue> Prices
        {
            get { return _prices; }
            private set { SetProperty(ref _prices, value); }
        }
        #endregion

        #region Methods
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null)
            {
                base.OnNavigatedTo(e, viewModelState);

                if (e.NavigationMode == NavigationMode.Refresh)
                {
                    //// Restores the error collection manually
                    var errorsCollection = RetrieveEntityStateValue<IDictionary<string, ReadOnlyCollection<string>>>("errorsCollection", viewModelState);

                    if (errorsCollection != null)
                    {
                        AppSpecification.SetAllErrors(errorsCollection);
                    }
                    // elase set defaults
                }

 
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                var param = e.Parameter as AppDetail;

                if (param != null)
                {
                    AppDetail = param;
                    AppSpecification = AppDetail.AppSpecification ?? new AppSpecification();
                    AppTypeValue = (int)AppSpecification.AppType;
                }
            }

            PopulateAppTypesAsync();
            PopulateCategoriesAsync();
            PopulateAppPricesAsync();

        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                AddEntityStateValue("errorsCollection", this.AppSpecification.GetAllErrors(), viewModelState);
            }
        }

        public void PopulateAppTypesAsync()
        {
            var items = new List<ComboBoxItemValue>
            {
                new ComboBoxItemValue() {Id = 0, Value = string.Empty},
                new ComboBoxItemValue()
                {
                    Id = ((byte) AppType.Application),
                    Value = _resourceLoader.GetString(AppType.Application.ToString())
                },
                new ComboBoxItemValue()
                {
                    Id = ((byte) AppType.Game),
                    Value = _resourceLoader.GetString(AppType.Game.ToString())
                }
            };


            AppTypes = new ReadOnlyCollection<ComboBoxItemValue>(items);

            // Select the first item on the list
            // But disable validation first, because we don't want to fire validation at this point
            //AppSpecification.IsValidationEnabled = false;
            //AppSpecification.AppType = AppType.None;
            //AppSpecification.IsValidationEnabled = true;
        }

        public async Task PopulateCategoriesAsync()
        {

            var categories = await _developerService.GetAppCategoriesAsync();

            var items = new List<ComboBoxItemValue> {new ComboBoxItemValue() {Id = 0, Value = string.Empty}};
            var appCategories = categories as IList<AppCategory> ?? categories.Where(c => c.AppType == AppSpecification.AppType ).ToList();

                items.AddRange(
                    appCategories.Select(
                        category => new ComboBoxItemValue() {Id = category.Id, Value = category.Title}));

            Categories = new ReadOnlyCollection<ComboBoxItemValue>(items);

            int temp = AppSpecification.CategoryId;
            AppSpecification.CategoryId = 0;
            AppSpecification.CategoryId = temp;
           
            //if (appCategories.Count > 0)
            //{
            // Select the first item on the list
            // But disable validation first, because we don't want to fire validation at this point
            //AppSpecification.IsValidationEnabled = false;
            //AppSpecification.CategoryId = appCategories.First().Id;
            //AppSpecification.IsValidationEnabled = true;
            // }
        }

        public void PopulateAppPricesAsync()
        {
            var items = new List<ComboBoxItemValue>
            {
                new ComboBoxItemValue(){Id = 0,Value = "رایگان"},
                new ComboBoxItemValue(){Id = 10,Value = "100"},
                new ComboBoxItemValue(){Id = 200,Value = "200"},
                //new ComboBoxItemValue(){Id = "300",Value = "300"},
                //new ComboBoxItemValue(){Id = "400",Value = "400"},
                //new ComboBoxItemValue(){Id = "500",Value = "500"},
                //new ComboBoxItemValue(){Id = "600",Value = "600"},
                //new ComboBoxItemValue(){Id = "700",Value = "700"},
                //new ComboBoxItemValue(){Id = "800",Value = "800"},
                //new ComboBoxItemValue(){Id = "900",Value = "900"},
                //new ComboBoxItemValue(){Id = "1000",Value = "1000"},
                //new ComboBoxItemValue(){Id = "1100",Value = "1100"},
            };


            Prices = new ReadOnlyCollection<ComboBoxItemValue>(items);

            // Select the first item on the list
            // But disable validation first, because we don't want to fire validation at this point
            //AppSpecification.IsValidationEnabled = false;
            //AppSpecification.Price = 0;
            //AppSpecification.IsValidationEnabled = true;
        }
       

        public async Task CheckAppNameIsAvailable(string appName)
        {
            var appNameIsAvailable = await _developerService.AppNameIsAvailbleAsync(appName, AppSpecification.AppId);

            if (!appNameIsAvailable)
            {
                var errorDictionary = new Dictionary<string, ReadOnlyCollection<string>>
                {
                    {
                        nameof(AppSpecification.Name),
                        new ReadOnlyCollection<string>(new List<string>
                        {
                            _resourceLoader.GetString("AppNameIsNotAvailable")
                        })
                    }
                };
                AppSpecification.SetAllErrors(errorDictionary);
            }
        }

        #endregion

        #region Commands
        public DelegateCommand SaveAppSpecificationCommand { get; }
        #endregion

        #region Actions

        private async void SaveAppSpecificationAsync()
        {
            // if validation is true signup person
            if (!this.AppSpecification.ValidateProperties()) return;

            if (AppSpecification.AppId == 0)
            {
                AppDetail.AppSpecification = await _developerService.RegisterAppSpecificationAsync(AppSpecification);
            }
            else
            {
                await _developerService.UpdateAppSpecificationAsync(AppSpecification);
            }

            _navigationService.Navigate(ViewNames.AppDetail, AppDetail);
        }

        #endregion

    }
}
