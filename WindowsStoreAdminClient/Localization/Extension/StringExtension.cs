using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.Admin.Localization.Extension
{
    public static class StringExtension
    {
        public static string Localize(this string str)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var localizedStr = loader.GetString(str);
            return string.IsNullOrEmpty(localizedStr) ? str : localizedStr;
        }
    }
}
