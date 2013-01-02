using System;
using System.ComponentModel;
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

namespace PatrolControl.UI.Screens.Common
{
    public class ObjectEditorViewModel : PropertyChangedBase
    {
        private bool _isEditing;
        private object _target;

        public ObjectEditorViewModel()
        {

        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                if (value == _isEditing) return;
                _isEditing = value;
                NotifyOfPropertyChange(() => IsEditing);
            }
        }

        public object Target
        {
            get { return _target; }
            set
            {
                if (Equals(value, _target)) return;
                _target = value;
                NotifyOfPropertyChange(() => Target);
            }
        }

        public void Edit(object o)
        {
            Target = o;
            IsEditing = true;
            var ieo = Target as IEditableObject;
            if (ieo != null)
                ieo.BeginEdit();
        }

        public void Save()
        {

        }

        public void Cancel()
        {

        }

    }
}
