using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace WindowsStore.Client.User.Common.Infrastructure
{
    public class IncrementalLoaderCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        Func<IncrementalLoaderCollection<T>, bool> _hasMoreItemsCallBack;
        Func<IncrementalLoaderCollection<T>, uint, Task<LoadMoreItemsResult>> _loadMoreItemsAsyncCallBack;

        public IncrementalLoaderCollection(
            Func<IncrementalLoaderCollection<T>, bool> hasMoreItemsCallback,
            Func<IncrementalLoaderCollection<T>, uint, Task<LoadMoreItemsResult>> loadMoreItemsAsyncCallback)
        {
            if (hasMoreItemsCallback == null || loadMoreItemsAsyncCallback == null) throw new ArgumentNullException();
            _hasMoreItemsCallBack = hasMoreItemsCallback;
            _loadMoreItemsAsyncCallBack = loadMoreItemsAsyncCallback;
        }

        bool ISupportIncrementalLoading.HasMoreItems
        {
            get
            {
                return _hasMoreItemsCallBack(this);
            }
        }

        IAsyncOperation<LoadMoreItemsResult> ISupportIncrementalLoading.LoadMoreItemsAsync(uint count)
        {
            return _loadMoreItemsAsyncCallBack(this, count).AsAsyncOperation();
        }
    }
}
