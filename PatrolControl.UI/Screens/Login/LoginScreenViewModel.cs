using System;
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
            ObjectEditor = new ObjectEditorViewModel();
            ObjectEditor.Edit(new EditableAdapter<Street>(new Street() {Id = 3, Name = "Hello"}));
        }

        [Dependency]
        public ShellViewModel ShellViewModel { get; set; }

        [Dependency]
        public Func<MapEditorScreenViewModel> MapEditorScreen { get; set; }

        public ObjectEditorViewModel ObjectEditor { get; set; }

        public void StartMapEditor()
        {
            ShellViewModel.Push(MapEditorScreen());
        }



    }
}
