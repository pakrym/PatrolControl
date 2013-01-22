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

namespace PatrolControl.UI.Screens.Shell
{
    public class BusyIndicatorViewModel : PropertyChangedBase
    {
        private Stack<string> _messages;

        public BusyIndicatorViewModel()
        {
            _messages = new Stack<string>();
        }

        public string Messages { get { return string.Join(Environment.NewLine, _messages); } }

        public bool IsBusy { get { return _messages.Count > 0; } }

        public void Pop()
        {
            _messages.Pop();
            NotifyOfPropertyChange(() => Messages);
            NotifyOfPropertyChange(() => IsBusy);
        }

        public void Push(string message)
        {
            _messages.Push(message);
            NotifyOfPropertyChange(() => Messages);
            NotifyOfPropertyChange(() => IsBusy);
        }
    }
}
