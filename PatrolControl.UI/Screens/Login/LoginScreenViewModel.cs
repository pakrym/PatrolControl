﻿using System;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.MapEditor;
using PatrolControl.UI.Screens.Shell;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Login
{
    public class LoginScreenViewModel : PropertyChangedBase
    {
        public LoginScreenViewModel()
        {
        }

        public string Login { get; set; }
        public string Password { get; set; }

        [Dependency]
        public ShellViewModel ShellViewModel { get; set; }

        [Dependency]
        public Func<MapEditorScreenViewModel> MapEditorScreen { get; set; }

        public void DoLogin()
        {
            ShellViewModel.Push(MapEditorScreen());
        }
        


    }
}
