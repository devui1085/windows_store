using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.Developer.UI.Views;

namespace WindowsStore.Client.Developer.UI.Converters
{
    /// <summary>
    /// Value converter that translates FormStatus.Complete or FormStatus.Invalid to <see cref="Visibility.Visible"/>
    /// and FormStatus.Incomplete to <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public sealed class FormStatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is int && ((int)value) == FormStatus.Incomplete) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
