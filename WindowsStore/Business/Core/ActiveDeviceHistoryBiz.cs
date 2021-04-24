using Store.Business.Interface;
using Store.Common.ExtensionMethod;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System;

namespace Store.Business.Core
{
    public class ActiveDeviceHistoryBiz : BaseBiz<ActiveDeviceHistory>, IActiveDeviceHistoryBiz
    {
        private readonly WindowsStoreContext _context;

        public ActiveDeviceHistoryBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }

        public void IncrementTodayActiveDevicesCount()
        {
            var today = DateTime.Now.Date;
            var activeDeviceHistory = SingleOrDefault(adh => adh.Date == today);

            if (activeDeviceHistory != null) {
                activeDeviceHistory.ActiveDeviceCount++;
                return;
            }

            Create(new ActiveDeviceHistory() {
                Date = today,
                ActiveDeviceCount = 1
            });
        }
    }
}
