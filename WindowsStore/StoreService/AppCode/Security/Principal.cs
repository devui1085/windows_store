using System.Web;

namespace Store.StoreService.AppCode.Security
{
    public class Principal
    {
        const string Key = "UserPrincipal";

        public static UserPrincipal CurrentUser
        {
            get
            {
                return (UserPrincipal)HttpContext.Current.Session[Key];
            }
            set
            {
                HttpContext.Current.Session[Key] = value;
            }
        }

        public static bool IsAuthenticated => HttpContext.Current.Session[Key] != null;
    }
}