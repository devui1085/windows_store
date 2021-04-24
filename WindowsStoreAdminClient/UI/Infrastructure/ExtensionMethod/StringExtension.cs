using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.Admin.UI.Infrastructure.ExtensionMethod
{
    public static class StringExtension
    {
        public static string Localize(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "";
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var localizedStr = loader.GetString(str);
            return string.IsNullOrEmpty(localizedStr) ? str : localizedStr;
        }
    }
}
