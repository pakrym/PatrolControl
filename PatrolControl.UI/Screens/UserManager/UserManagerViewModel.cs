﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.Editors;
using PatrolControl.UI.Screens.Common.ListManager;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Screens.UserManager
{
    public class UserManagerView : ListManagerView
    {

    }
    public class UserManagerViewModel : ListManagerViewModel<User, UserViewModel>
    {
        public UserManagerViewModel(ICrud<User> crud, ObjectEditorViewModel objectEditorViewModel, Func<User, UserViewModel> vmCreator) : base(crud, objectEditorViewModel, vmCreator)
        {
        }

        public override string DisplayName
        {
            get
            {
                return "User Manager";
            }
        }



    }

}
