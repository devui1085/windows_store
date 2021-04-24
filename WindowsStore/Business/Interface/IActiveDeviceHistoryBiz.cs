using Store.DomainModel.Entity;
using System.Linq;
using Store.DomainModel.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Common.Enum;
using Store.Business.Core;

namespace Store.Business.Interface
{
    public interface IActiveDeviceHistoryBiz : IBaseBiz<ActiveDeviceHistory>
    {
        void IncrementTodayActiveDevicesCount();
    }
}
