using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;

namespace Store.Business.Core
{
    public class AppCategoryBiz: BaseBiz<AppCategory>,  IAppCategoryBiz
    {
        private readonly WindowsStoreContext _context;

        public AppCategoryBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
