namespace WindowsStore.Client.Developer.UI.Infrastructure.ExtensionMethod
{
    public static class StringExtension
    {
        public static string Localize(this string str)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            return loader.GetString(str);
        }
    }
}
