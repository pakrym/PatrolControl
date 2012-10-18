using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using Microsoft.Practices.Unity;

namespace PatrolControl.UI
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

    public class MapEditorScreenViewModel: PropertyChangedBase
    {
        
    }
}
