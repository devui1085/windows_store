using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WindowsStore.Client.Developer.UI.Converters
{
    public class TextToHeaderVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is string)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
