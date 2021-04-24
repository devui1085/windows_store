using Windows.ApplicationModel.Resources;
using Prism.Windows.AppModel;

namespace WindowsStore.Client.Developer.Logic.Services
{
    public static class ResourceStringsHelper
    {
        static ResourceStringsHelper()
        {
            ResourceLoader = new ResourceLoaderAdapter(new ResourceLoader());    
        }

        public static IResourceLoader ResourceLoader { get;  }

        public static string Close => ResourceLoader.GetString("Close");
        public static string CompleteLable => ResourceLoader.GetString("CompleteLable");
        public static string IncompleteLable => ResourceLoader.GetString("IncompleteLable");
      
        #region Errors

        public static string RequiredErrorMessage => ResourceLoader.GetString("ErrorRequired");
        public static string RegexErrorMessage => ResourceLoader.GetString("ErrorRegex");
        public static string InvalidEmailErrorMessage => ResourceLoader.GetString("ErrorInvalidEmail");
        public static string PasswordLengthInvalidErrorMessage => ResourceLoader.GetString("ErrorPasswordLengthInvalid");
        public static string VersionNumberRequiredErrorMessage => ResourceLoader.GetString("VersionNumberRequired");

        #endregion

    }
}
