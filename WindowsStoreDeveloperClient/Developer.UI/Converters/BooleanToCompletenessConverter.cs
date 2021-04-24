using System;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.Developer.Logic.Services;

namespace WindowsStore.Client.Developer.UI.Converters
{
    /// <summary>
    /// Value converter that translates true to <see cref="ResourceStringsHelper.CompleteLable"/> 
    /// and false to <see cref="ResourceStringsHelper.IncompleteLable"/>.
    /// </summary>
    public sealed class BooleanToCompletenessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? ResourceStringsHelper.CompleteLable : ResourceStringsHelper.IncompleteLable;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //return value is Visibility && (Visibility)value == Visibility.Visible;
            throw new Exception();
        }
    }
}
