using System.Collections.Generic;
using WindowsStore.Client.User.Common.ExtensionMethod;

namespace WindowsStore.Client.User.Common.Enum
{
    public static class EnumHelper
    {
        public static IEnumerable<EnumTextValuePair<TEnum>> GetTitleValuePairs<TEnum>() where TEnum : struct
        {
            var collection = new List<EnumTextValuePair<TEnum>>();
            var enumType = typeof(TEnum);
            var enumTypeString = enumType.Name.ToString();
            System.Enum.GetNames(enumType).ForEach(enumName =>
            {
                TEnum enumValue;
                System.Enum.TryParse<TEnum>(enumName, out enumValue);
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
