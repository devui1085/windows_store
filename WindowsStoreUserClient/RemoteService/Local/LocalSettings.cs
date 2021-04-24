using Windows.Storage;

namespace WindowsStore.Client.User.Service.Local
{
    public static class LocalSettings
    {
        static ApplicationDataContainer _localSetting;

        static ApplicationDataContainer Settings
        {
            get
            {
                if (_localSetting == null)
                    _localSetting = ApplicationData.Current.LocalSettings;
                return _localSetting;
            }
        }

        public static object Get(string key)
        {
            return Settings.Values[key];
        }

        public static void Set(string key, object value)
        {
            Settings.Values[key] = value;
        }
    }
}
