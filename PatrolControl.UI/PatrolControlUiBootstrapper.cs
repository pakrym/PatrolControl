using System;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Screens.Login;
using PatrolControl.UI.Screens.Shell;

namespace PatrolControl.UI
{
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