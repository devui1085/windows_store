using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System.Linq;
using Store.Common.Enum;
using Store.DomainModel.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Common.Configuration;
using System.IO;

namespace Store.Business.Core
{
    public class PlatformBiz : BaseBiz<Platform>, IPlatformBiz
    {
        private readonly WindowsStoreContext _context;

        public PlatformBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
