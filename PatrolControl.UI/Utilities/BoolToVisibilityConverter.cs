using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Caliburn.Micro;

namespace PatrolControl.UI.Utilities
{

    public class ViewModelHelper : DependencyObject
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.RegisterAttached(
                      "ViewModel",                  //Name of the property
                      typeof(object),             //Type of the property
                      typeof(ViewModelHelper),   //Type of the provider of the registered attached property
                      new PropertyMetadata(null, ViewModelChanged)
                      );                           //Callback invoked in case the property value has changed

        private static void ViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var aware = e.NewValue as IViewAware;
            if (aware != null)
            {
                aware.AttachView(d);
            }
        }


        public ViewModelHelper()
        {
        }

        public static void SetViewModel(DependencyObject obj, object tabStop)
        {
            obj.SetValue(ViewModelProperty, tabStop);
        }

        public static object GetViewModel(DependencyObject obj)
        {
            return obj.GetValue(ViewModelProperty);
        }
    }
    public class BoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public BoolToVisibilityConverter()
        {
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Collapsed;
        }

        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = System.Convert.ToBoolean(value);
            return val ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return TrueValue.Equals(value) ? true : false;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}