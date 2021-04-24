using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.Developer.Common.Enum;

namespace WindowsStore.Client.Developer.UI.Converters
{
   public sealed class PersonTypeToVisibilityConvertor : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
            var paramvalue = Enum.Parse(value.GetType(), parameter.ToString());
            return paramvalue.Equals(value)? Visibility.Visible: Visibility.Collapsed;
        }

       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
           return Enum.Parse(typeof(PersonType), parameter.ToString());
       }
    }
}
