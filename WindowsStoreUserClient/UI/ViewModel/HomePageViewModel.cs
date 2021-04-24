using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.View.Interface;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        public IHomePage View { get; set; }
        public ObservableCollection<StoreApp> RandomApps { get; set; }
        public ObservableCollection<StoreApp> TopApplications { get; set; }
        public ObservableCollection<StoreApp> TopGames { get; set; }
        public ObservableCollection<StoreApp> FeaturedApps { get; set; }

        public bool ShowRandomAppsSection
        {
            get
            {
                return RandomApps.Count() > 0;
            }
        }

        public bool ShowTopApplicationsSection
        {
            get
            {
                return TopApplications.Count() > 0;
            }
        }

        public bool ShowTopGamesSection
        {
            get
            {
                return TopGames.Count() > 0;
            }
        }

        public HomePageViewModel()
        {
            RandomApps = new ObservableCollection<StoreApp>();
            TopApplications = new ObservableCollection<StoreApp>();
            TopGames = new ObservableCollection<StoreApp>();
            FeaturedApps = new ObservableCollection<StoreApp>();
        }

        public async Task LoadAppsAsync()
        {
            UiManager.ShowLoading();
            View.HideNetworkErrorMessage();
            try
            {
                await LoadFeaturedAppsAsync();
                await LoadRandomAppsAsync();
                await LoadTopApplicationsAsync();
                await LoadTopGamesAsync();
            }
            catch (Exception exp)
            {
                View.ShowNetworkErrorMessage();
            }

            UiManager.HideLoading();
        }

        public async Task LoadFeaturedAppsAsync()
        {
            var apps = await AppManager.Instance.GetAppsAsync(AppQueryParameters.FeaturedApps());
            apps.ForEach(async app =>
            {
                FeaturedApps.Add(app);
                try
                {
                    app.BackgroundImage = await AppManager.Instance.GetAppBackgroundImageAsync(app.Guid);
                    RaisePropertyChanged(nameof(FeaturedApps));
                    View.SetFlipViewHeight();
                }
                catch
                {

                }
            });
        }

        public async Task LoadRandomAppsAsync()
        {
            IEnumerable<StoreApp> apps = null;
            var queryParams = AppQueryParameters.RandomApps(1);
            var i = RandomApps.Count;
            do {
                queryParams.PageIndex = i;
                apps = await AppManager.Instance.GetRandomAppsAsync(queryParams);
                apps.ForEach(app => RandomApps.Add(app));
                RaisePropertyChanged(nameof(ShowRandomAppsSection));
                i++;
            } while (i < 5 && apps.Count() > 0);
        }

        public async Task LoadTopApplicationsAsync()
        {
            IEnumerable<StoreApp> apps = null;
            var queryParams = AppQueryParameters.TopApplications(0, 1);
            var i = TopApplications.Count;
            do {
                queryParams.PageIndex = i;
                apps = await AppManager.Instance.GetAppsAsync(queryParams);
                apps.ForEach(app => TopApplications.Add(app));
                RaisePropertyChanged(nameof(ShowTopApplicationsSection));
                i++;
            } while (i < 5 && apps.Count() > 0);
        }

        public async Task LoadTopGamesAsync()
        {
            IEnumerable<StoreApp> apps = null;
            var queryParams = AppQueryParameters.TopGames(0, 1);
            var i = TopGames.Count;
            do {
                queryParams.PageIndex = i;
                apps = await AppManager.Instance.GetAppsAsync(queryParams);
                apps.ForEach(app => TopGames.Add(app));
                RaisePropertyChanged(nameof(ShowTopGamesSection));
                i++;
            } while (i < 5 && apps.Count() > 0);
        }
    }
}
