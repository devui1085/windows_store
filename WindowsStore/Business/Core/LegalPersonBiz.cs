using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;

namespace Store.Business.Core
{
    public class LegalPersonBiz : BaseBiz<LegalPerson>, ILegalPersonBiz
    {
        private readonly WindowsStoreContext _context;

        public LegalPersonBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
