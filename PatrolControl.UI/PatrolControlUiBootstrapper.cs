using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Screens.Login;
using PatrolControl.UI.Screens.Shell;
using PatrolControl.UI.Utilities;
using System.Diagnostics;

namespace PatrolControl.UI
{

    class DebugLogger : ILog
    {
        #region Fields
        private readonly Type _type;
        #endregion

        #region Constructors
        public DebugLogger(Type type)
        {
            _type = type;
        }
        #endregion

        #region Helper Methods
        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}",
                                 DateTime.Now.ToString("o"),
                                 string.Format(format, args));
        }
        #endregion

        #region ILog Members
        public void Error(Exception exception)
        {
            Debug.WriteLine(CreateLogMessage(exception.ToString()), "ERROR");
        }
        public void Info(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage(format, args), "INFO");
        }
        public void Warn(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage(format, args), "WARN");
        }
        #endregion
    }

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


    public class PatrolControlUiBootstrapper : Bootstrapper<ShellViewModel>
    {
        private UnityContainer _container;

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            Caliburn.Micro.LogManager.GetLog = type => new DebugLogger(type);
            base.OnStartup(sender, e);
            var baseLocate = ViewLocator.LocateTypeForModelType;

            ViewLocator.LocateTypeForModelType = (modelType, displayLocation, context) =>
            {
                if (modelType.IsGenericType && modelType.GetGenericTypeDefinition() == typeof(EditableAdapter<>))
                {
                    var subtype = modelType.GetGenericArguments().First();
                    return Type.GetType("PatrolControl.UI.Screens.Common.Editors." + subtype.Name);
                }
                else
                {
                    return baseLocate(modelType, displayLocation, context);
                }
            };
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