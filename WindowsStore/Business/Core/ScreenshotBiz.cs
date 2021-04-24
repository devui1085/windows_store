using Store.DomainModel.Entity;
using System;
using Store.Business.Interface;
using Store.DataAccess.Context;

namespace Store.Business.Core
{
    public class ScreenshotBiz : BaseBiz<Screenshot>, IScreenshotBiz
    {
        private readonly WindowsStoreContext _context;

        public ScreenshotBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
