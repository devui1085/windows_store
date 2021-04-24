using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.ExtensionMethod;

namespace WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod
{

    public static class NumericDataTypesExtension
    {

        public static string ToSizeString(this ulong size, bool useLocalizedUnitWords = true)
        {
            return ConvertToSizeString(size, useLocalizedUnitWords);
        }

        public static string ToSizeString(this long size, bool useLocalizedUnitWords = true)
        {
            return ConvertToSizeString((ulong)size, useLocalizedUnitWords);
        }

        public static string ToSizeString(this uint size ,bool useLocalizedUnitWords = true)
        {
            return ConvertToSizeString(size, useLocalizedUnitWords);
        }

        public static string ToSizeString(this int size, bool useLocalizedUnitWords = true)
        {
            return ConvertToSizeString((ulong)size, useLocalizedUnitWords);
        }

        static string ConvertToSizeString(ulong size, bool useLocalizedUnitWords)
        {
            ulong KB = 1024;
            ulong MB = KB * 1024;
            ulong GB = MB * 1024;
            string result;

            if (size < KB) {
                var byteString = (useLocalizedUnitWords ? "Byte".Localize() : "B");
                result = $"{size} {byteString}";
            }
            else if (size < MB) {
                var killoByteString = (useLocalizedUnitWords ? "KilloByte".Localize() : "KB");
                result = $"{size / KB} {killoByteString}";
            }
            else if (size < GB) {
                var megaByteString = (useLocalizedUnitWords ? "MegaByte".Localize() : "MB");
                result = $"{((float)size / MB).ToString("F1")} {megaByteString}";
            }
            else {
                var gigaByteString = (useLocalizedUnitWords ? "GigaByte".Localize() : "GB");
                result = $"{((float)size / GB).ToString("F2")} {gigaByteString}";
            }
            return result;
        }

    }
}
