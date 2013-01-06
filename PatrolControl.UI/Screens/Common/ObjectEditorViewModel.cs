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
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common
{
    public class ObjectEditorViewModel : PropertyChangedBase
    {
        private bool _isEditing;
        private object _target;

        public ObjectEditorViewModel()
        {
            CanDelete = false;
        }

        public bool CanDelete { get; set; }

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
            Target = EditableAdapter.CreateGeneric(o);

            IsEditing = true;
            var ieo = Target as IEditableObject;
            if (ieo != null)
                ieo.BeginEdit();
        }

        public void Save()
        {
            var ieo = Target as IEditableObject;
            if (ieo != null)
                ieo.EndEdit();
            EndEdit();
            OnSaved();
        }

        public void Cancel()
        {
            var ieo = Target as IEditableObject;
            if (ieo != null)
                ieo.CancelEdit();
            EndEdit();
            OnCancelled();
        }

        public void Delete()
        {
            var ieo = Target as IEditableObject;
            if (ieo != null)
                ieo.CancelEdit();
            EndEdit();
            OnDeleted();
        }

        private void EndEdit()
        {
            Target = null;
            IsEditing = false;
        }

        public event EventHandler Saved;

        protected virtual void OnSaved()
        {
            EventHandler handler = Saved;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler Cancelled;

        protected virtual void OnCancelled()
        {
            EventHandler handler = Cancelled;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler Deleted;

        protected virtual void OnDeleted()
        {
            EventHandler handler = Deleted;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
