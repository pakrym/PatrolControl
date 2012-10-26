using System.Collections.Generic;
using Caliburn.Micro;

namespace PatrolControl.UI.Screens.Shell
{
    public class ShellViewModel : PropertyChangedBase
    {
        private Stack<object> _screenStack;
        private object _activePage;

        public ShellViewModel()
        {
            _screenStack = new Stack<object>();
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
