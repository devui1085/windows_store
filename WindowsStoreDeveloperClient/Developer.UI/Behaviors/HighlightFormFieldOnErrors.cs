using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.UI.Behaviors
{
    // Documentation on validating user input is at http://go.microsoft.com/fwlink/?LinkID=288817&clcid=0x409
    public class HighlightFormFieldOnErrors : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty PropertyErrorsProperty =
            DependencyProperty.RegisterAttached("PropertyErrors", typeof(object), typeof(HighlightFormFieldOnErrors), new PropertyMetadata(BindableValidator.EmptyErrorsCollection, OnPropertyErrorsChanged));
        
        // The default for this property only applies to TextBox controls.
        public static readonly DependencyProperty HighlightTextBoxStyleNameProperty =
            DependencyProperty.RegisterAttached("HighlightTextBoxStyleName", typeof(string), typeof(HighlightFormFieldOnErrors), new PropertyMetadata("HighlightTextBoxStyle"));  
        
        // The default for this property only applies to PasswordBox controls.
        public static readonly DependencyProperty HighlightPasswordBoxStyleNameProperty =
            DependencyProperty.RegisterAttached("HighlightPasswordBoxStyleName", typeof(string), typeof(HighlightFormFieldOnErrors), new PropertyMetadata("HighlightPasswordBoxStyle"));
        
        // The default for this property only applies to TextBox controls.
        protected static readonly DependencyProperty OriginalTextBoxStyleNameProperty =
            DependencyProperty.RegisterAttached("OriginalTextBoxStyleName", typeof(Style), typeof(HighlightFormFieldOnErrors), new PropertyMetadata("BaseTextBoxStyle"));

        // The default for this property only applies to PasswordBox controls.
        protected static readonly DependencyProperty OriginalPasswordBoxStyleNameProperty =
            DependencyProperty.RegisterAttached("OriginalPasswordBoxStyleName", typeof(Style), typeof(HighlightFormFieldOnErrors), new PropertyMetadata("BasePasswordBoxStyle"));

        public object PropertyErrors
        {
            get { return (object)GetValue(PropertyErrorsProperty); }
            set { SetValue(PropertyErrorsProperty, value); }
        }

        public string HighlightTextBoxStyleName
        {
            get { return (string)GetValue(HighlightTextBoxStyleNameProperty); }
            set { SetValue(HighlightTextBoxStyleNameProperty, value); }
        }

        public string HighlightPasswordBoxStyleName
        {
            get { return (string)GetValue(HighlightPasswordBoxStyleNameProperty); }
            set { SetValue(HighlightPasswordBoxStyleNameProperty, value); }
        }


        public string OriginalTextBoxStyleName
        {
            get { return (string)GetValue(OriginalTextBoxStyleNameProperty); }
            set { SetValue(OriginalTextBoxStyleNameProperty, value); }
        }
        public string OriginalPasswordBoxStyleName
        {
            get { return (string)GetValue(OriginalPasswordBoxStyleNameProperty); }
            set { SetValue(OriginalPasswordBoxStyleNameProperty, value); }
        }
        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        private static void OnPropertyErrorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args?.NewValue == null)
            {
                return;
            }

            var control = ((Behavior<FrameworkElement>) d).AssociatedObject;
            var propertyErrors = (ICollection<string>) args.NewValue;

            Style style = null;

            if (control is Windows.UI.Xaml.Controls.TextBox)
            {
                style = propertyErrors.Any()
                    ? (Style) Application.Current.Resources[((HighlightFormFieldOnErrors) d).HighlightTextBoxStyleName]
                    : (Style) Application.Current.Resources[((HighlightFormFieldOnErrors) d).OriginalTextBoxStyleName];
            }
            else if (control is Windows.UI.Xaml.Controls.PasswordBox)
            {
                style = propertyErrors.Any()
                    ? (Style)
                        Application.Current.Resources[((HighlightFormFieldOnErrors) d).HighlightPasswordBoxStyleName]
                    : (Style) Application.Current.Resources[((HighlightFormFieldOnErrors) d).OriginalPasswordBoxStyleName];
            }

            control.Style = style;
        }
    }
}
