using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;

namespace Store.Business.Core
{
    public class NaturalPersonBiz : BaseBiz<NaturalPerson>, INaturalPersonBiz
    {
        private readonly WindowsStoreContext _context;

        public NaturalPersonBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
