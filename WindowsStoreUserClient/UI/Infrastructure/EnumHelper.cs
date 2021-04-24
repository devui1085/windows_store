using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.UI.Infrastructure
{
    public static class EnumHelper
    {
        public static IEnumerable<EnumTextValuePair<TEnum>> GetTitleValuePairs<TEnum>() where TEnum : struct
        {
            var collection = new List<EnumTextValuePair<TEnum>>();
            var enumType = typeof(TEnum);
            var enumTypeString = enumType.Name.ToString();
            Enum.GetNames(enumType).ForEach(enumName =>
            {
                TEnum enumValue;
                Enum.TryParse<TEnum>(enumName, out enumValue);
                collection.Add(new EnumTextValuePair<TEnum>()
                {
                    Text = string.Format("{0}_{1}", enumTypeString, enumName).Localize(),
                    Value = enumValue
                });
            });
            return collection;
        }

        public static string LocalizeEnumItem<TEnum>(TEnum enumItem) where TEnum : struct
        {
            return string.Format("{0}_{1}", typeof(TEnum).Name.ToString(), enumItem).Localize();
        }
    }


}
