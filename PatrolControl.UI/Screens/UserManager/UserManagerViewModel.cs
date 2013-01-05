using System;
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
using PatrolControl.UI.Screens.Common;

namespace PatrolControl.UI.Screens.UserManager
{
    public class UserManagerViewModel : Screen
    {
        public override string DisplayName
        {
            get
            {
                return "User Manager";
            }
        }


        private object _selectedUser;

        public UserManagerViewModel()
        {
            ObjectEditor = new ObjectEditorViewModel();
        }

        public ObjectEditorViewModel ObjectEditor { get; set; }

        public object SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (Equals(value, _selectedUser)) return;
                _selectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        public void Add()
        {

        }
    }

}
