﻿using System;
<<<<<<< HEAD
=======
using System.ComponentModel;
>>>>>>> origin/master
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
<<<<<<< HEAD

namespace PatrolControl.UI.Screens.Common
{
    public class ObjectEditorViewModel
    {

        public void Save()
        {
            
=======
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
>>>>>>> origin/master
        }

        public void Cancel()
        {
<<<<<<< HEAD
            
        }

=======
            var ieo = Target as IEditableObject;
            if (ieo != null)
                ieo.CancelEdit();
            EndEdit();
        }

        private void EndEdit()
        {
            Target = null;
            IsEditing = false;
        }


>>>>>>> origin/master
    }
}
