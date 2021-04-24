using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace WindowsStore.Client.Developer.UI.Converters
{
    /// <summary>
    /// Value converter that translates true to <see cref="Symbol.Emoji2"/> 
    /// and false to <see cref="Symbol.Important"/>.
    /// </summary>
    public sealed class BooleanToSymbolIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? Symbol.Emoji2 : Symbol.Important;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //return value is Visibility && (Visibility)value == Visibility.Visible;
            throw new Exception();
        }
    }
}
