using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace WindowsStore.Client.Developer.UI.Converters
{
    /// <summary>
    /// Value converter that translates true to <see cref="Colors.Blue"/> 
    /// and false to <see cref="Colors.Red"/>.
    /// </summary>
    public sealed class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var parameters = parameter.ToString().Split(new char[] {':'});
            return (value is bool && (bool) value) ? parameters[0] : parameters[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new Exception();
        }
    }
}
