using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.Developer.UI.Views;

namespace WindowsStore.Client.Developer.UI.Converters
{
    /// <summary>
    /// Value converter that translates FormStatus.Complete to ValidFormStatus{commandParameter}Style
    /// and the others to InvalidFormStatus{commandParameter}Style.
    /// </summary>
    public sealed class FormStatusToStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string styleKey = (value is int && ((int)value) == FormStatus.Complete) ? string.Format(CultureInfo.CurrentCulture, "ValidFormStatus{0}Style", parameter)
                                                                                        : string.Format(CultureInfo.CurrentCulture, "InvalidFormStatus{0}Style", parameter);

            object style = null;
            Application.Current.Resources.TryGetValue(styleKey, out style);

            return (Style)style;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
