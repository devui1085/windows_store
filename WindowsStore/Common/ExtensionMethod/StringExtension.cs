using System;
using System.Collections.Generic;

namespace Store.Common.ExtensionMethod
{
    public static class StringExtension
    {
        public static string Localize<T>(this string str)
        {
            var localizedString = Store.Localization.Resources.ResourceManager.GetString(str);
            return localizedString == null ? str : localizedString;
        }
    }
}
