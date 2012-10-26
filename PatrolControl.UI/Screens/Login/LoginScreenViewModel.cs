using System;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Screens.MapEditor;
using PatrolControl.UI.Screens.Shell;

namespace PatrolControl.UI.Screens.Login
{
    public class LoginScreenViewModel : PropertyChangedBase
    {
        [Dependency]
        public ShellViewModel ShellViewModel { get; set; }

        [Dependency]
        public Func<MapEditorScreenViewModel> MapEditorScreen { get; set; }

        public void StartMapEditor()
        {
            ShellViewModel.Push(MapEditorScreen());
        }
    }
}
