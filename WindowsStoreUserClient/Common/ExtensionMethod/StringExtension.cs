using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace WindowsStore.Client.User.Common.ExtensionMethod
{
    public static class StringExtension
    {
        private static ResourceLoader _resourceLoader;

        static StringExtension()
        {
        }

        public static string Localize(this string str)
        {
            _resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var result = _resourceLoader.GetString(str);
            return string.IsNullOrEmpty(result) ? str : result;
        }

        private static bool _invalidEmail;
        public static bool IsValidEmail(this string str)
        {
            _invalidEmail = false;
            if (String.IsNullOrEmpty(str))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try {
                str = Regex.Replace(str, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException) {
                return false;
            }

            if (_invalidEmail)
                return false;

            // Return true if strIn is in valid e-mail format.
            try {
                return Regex.IsMatch(str,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException) {
                return false;
            }
        }

        public static Version ToVersion(this string str)
        {
            return Version.Parse(str);
        }

        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException) {
                _invalidEmail = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
