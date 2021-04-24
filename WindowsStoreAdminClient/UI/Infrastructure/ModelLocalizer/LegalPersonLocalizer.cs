using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.Admin.UI.Infrastructure.ModelLocalizer
{
    public static class LegalPersonLocalizer
    {
        public static void LocalizeProperties(this LegalPerson legalPerson)
        {
            legalPerson.IsAdminText = (legalPerson.IsAdmin ? "Admin" : "").Localize();
            legalPerson.IsDeveloperText = (legalPerson.IsDeveloper ? "Developer" : "User").Localize();
            legalPerson.IsLockedOutText = (legalPerson.IsLockedOut ? "Locked" : "").Localize();
        }
    }
}
