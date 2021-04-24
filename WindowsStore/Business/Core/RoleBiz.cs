using System;
using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using Store.Common.Security;
using System.Linq;
using System.Collections.Generic;
using Store.Common.Enum;

namespace Store.Business.Core
{
    public class RoleBiz : BaseBiz<Role>, IRoleBiz
    {
        private readonly WindowsStoreContext _context;

        public RoleBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
