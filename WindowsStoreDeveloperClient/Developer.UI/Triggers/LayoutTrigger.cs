using Windows.UI.Core;
using Windows.UI.Xaml;

namespace WindowsStore.Client.Developer.UI.Triggers
{
    public enum LayoutStateType
    {
        Minimal, Portrait, Landscape
    }

    public class LayoutTrigger : StateTriggerBase
    {
        public static readonly DependencyProperty MinimalStateWidthProperty = DependencyProperty.Register("MinimalStateWidth", typeof(double), typeof(LayoutTrigger), new PropertyMetadata(720.0, OnTriggerPropertyChanged));

        public static readonly DependencyProperty LayoutStateProperty = DependencyProperty.Register("LayoutState", typeof(LayoutStateType), typeof(LayoutTrigger), new PropertyMetadata(LayoutStateType.Landscape, OnTriggerPropertyChanged));

        public LayoutTrigger()
        {
            Window.Current.SizeChanged += Window_SizeChanged;
            UpdateTrigger();
        }

        public double MinimalStateWidth
        {
            get
            {
                return (double)GetValue(MinimalStateWidthProperty);
            }

            set
            {
                SetValue(MinimalStateWidthProperty, value);
            }
        }

        public LayoutStateType LayoutState
        {
            get
            {
                return (LayoutStateType)GetValue(LayoutStateProperty);
            }

            set
            {
                SetValue(LayoutStateProperty, value);
            }
        }

        private static void OnTriggerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var trigger = d as LayoutTrigger;
            trigger?.UpdateTrigger();
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            UpdateTrigger();
        }

        private void UpdateTrigger()
        {
            switch (LayoutState)
            {
                case LayoutStateType.Minimal:
                    SetActive(Window.Current.Bounds.Width <= MinimalStateWidth);

                    break;
                case LayoutStateType.Portrait:
                    SetActive(Window.Current.Bounds.Width < Window.Current.Bounds.Height);

                    break;
                case LayoutStateType.Landscape:
                default:
                    SetActive(//Window.Current.Bounds.Width > Window.Current.Bounds.Height && 
                        Window.Current.Bounds.Width >= MinimalStateWidth);

                    break;
            }
        }
    }
}
