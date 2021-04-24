using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.Admin.UI.Infrastructure.ModelLocalizer
{
    public static class NaturalPersonLocalizer
    {
        public static void LocalizeProperties(this NaturalPerson naturalPerson)
        {
            naturalPerson.IsAdminText = (naturalPerson.IsAdmin ? "Admin" : "").Localize();
            naturalPerson.IsDeveloperText = (naturalPerson.IsDeveloper ? "Developer" : "User").Localize();
            naturalPerson.IsLockedOutText = (naturalPerson.IsLockedOut ? "Locked" : "").Localize();
        }
    }
}
