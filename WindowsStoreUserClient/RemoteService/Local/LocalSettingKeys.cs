using Windows.Storage;

namespace WindowsStore.Client.User.Service.Local
{
    public static class LocalSettingKeys
    {
        public static string LastUpdateCheck { get; set; } = "LastUpdateCheck";
        public static string AutomaticUpdate { get; set; } = "AutomaticUpdate";
        public static string UserName { get; set; } = "UserName";
        public static string UserPassword { get; set; } = "UserPassword";
    }
}
