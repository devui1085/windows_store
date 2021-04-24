using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System.Linq;
using Store.Common.Enum;
using Store.DomainModel.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Store.Business.Core
{
    public class AppVersionBiz : BaseBiz<AppVersion>, IAppVersionBiz
    {
        private readonly WindowsStoreContext _context;

        public AppVersionBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
