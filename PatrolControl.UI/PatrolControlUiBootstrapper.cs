using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Screens.Login;
using PatrolControl.UI.Screens.Shell;

namespace PatrolControl.UI
{

    public class DataContextProxy : DependencyObject
    {
        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(DataContextProxy), new PropertyMetadata(null));
    }

    public class DebuggingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class PatrolControlUiBootstrapper : Bootstrapper<ShellViewModel>
    {
        private UnityContainer _container;

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            _container.Resolve<ShellViewModel>().Push(_container.Resolve<LoginScreenViewModel>());
        }

        protected override void Configure()
        {
            _container = new UnityContainer();

            foreach (Type t in typeof(PatrolControlUiBootstrapper).Assembly.GetTypes())
            {
                if (t.Name.EndsWith("ViewModel"))
                {
                    _container.RegisterType(t);
                }
            }
            _container.RegisterType<ShellViewModel>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IFeatureLayerViewModel, BuildingFeatureLayerViewModel>("buildings");
            _container.RegisterType<IFeatureLayerViewModel, StreetFeatureLayerViewModel>("streets");

        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override System.Collections.Generic.IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.ResolveAll(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.Resolve(service, key);
        }

    }
}