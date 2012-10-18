using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Caliburn.Micro;
using Microsoft.Practices.Unity;

namespace PatrolControl.UI
{
    public class PatrolControlUiBootstrapper : Bootstrapper<ShellViewModel>
    {
        private UnityContainer _container;

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

       
    public class ShellViewModel : PropertyChangedBase
    {
        private Stack<object> _screenStack;
        private object _activePage;

        public ShellViewModel(LoginScreenViewModel loginScreen)
        {
            _screenStack = new Stack<object>();
            ActivePage = loginScreen;
        }

        public object ActivePage
        {
            get { return _activePage; }
            set
            {
                if (Equals(value, _activePage)) return;
                _activePage = value;
                NotifyOfPropertyChange(() => ActivePage);
            }
        }

        public void Push(object o)
        {
            _screenStack.Push(_screenStack);
            ActivePage = o;
        }

        public void Pop()
        {
            _screenStack.Pop();
            ActivePage = _screenStack.Peek();
        }
    }

    
}
