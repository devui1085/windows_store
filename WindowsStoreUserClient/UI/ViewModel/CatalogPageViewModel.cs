using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.View.Interface;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class CatalogPageViewModel : ViewModelBase
    {
        bool _hasMoreItems;

        public ICatalogPage View { get; set; }
        public AppQueryParameters AppQueryParameters { get; set; }
        public IncrementalLoaderCollection<StoreApp> StoreApps { get; set; }
        public List<StoreApp> TopApplications { get; set; }
        public List<StoreApp> TopGames { get; set; }
        public bool LoadingApps { get; set; }

        public CatalogPageViewModel()
        {
            StoreApps = new IncrementalLoaderCollection<StoreApp>(HasMoreItems, LoadMoreItemsAsync);
            TopApplications = new List<StoreApp>();
            TopGames = new List<StoreApp>();
            _hasMoreItems = true;
        }

        public void RestoreState()
        {
            // Restore Cached Apps
            StoreApps.Clear();
            _hasMoreItems = true;
            if (AppQueryParameters.AppType == AppType.Application)
                TopApplications.ForEach(app => StoreApps.Add(app));
            if (AppQueryParameters.AppType == AppType.Game)
                TopGames.ForEach(app => StoreApps.Add(app));
        }

        public void SaveState()
        {
            if (AppQueryParameters.AppType == AppType.Application) {
                TopApplications.Clear();
                StoreApps.ForEach(app => TopApplications.Add(app));
            }

            if (AppQueryParameters.AppType == AppType.Game) {
                TopGames.Clear();
                StoreApps.ForEach(app => TopGames.Add(app));
            }
        }

        private bool HasMoreItems(IncrementalLoaderCollection<StoreApp> dataSource)
        {
            return _hasMoreItems;
        }

        private async Task<LoadMoreItemsResult> LoadMoreItemsAsync(IncrementalLoaderCollection<StoreApp> collection, uint count)
        {
            List<StoreApp> loadedAapps = new List<StoreApp>();
            if (LoadingApps) {
                return new LoadMoreItemsResult() { Count = 0 };
            }

            UiManager.ShowLoading();
            AppQueryParameters.PageIndex = StoreApps.Count / AppQueryParameters.PageSize;
            LoadingApps = true;

            try {
                loadedAapps.AddRange(await AppManager.Instance.GetAppsAsync(AppQueryParameters));
                _hasMoreItems = (loadedAapps.Count() == AppQueryParameters.PageSize);
            }
            catch (Exception exp) {
                _hasMoreItems = false;
                View.ShowNetworkErrorMessage();
            }

            LoadingApps = false;
            loadedAapps.ForEach(app => collection.Add(app));
            UiManager.HideLoading();

            return new LoadMoreItemsResult() { Count = (uint)loadedAapps.Count };
        }
    }
}
