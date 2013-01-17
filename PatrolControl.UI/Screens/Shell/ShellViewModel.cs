using System.Collections.Generic;
using Caliburn.Micro;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Login;

namespace PatrolControl.UI.Screens.Shell
{
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        readonly LoginScreenViewModel _firstScreen;

        public ShellViewModel(LoginScreenViewModel firstScreen)
        {
            this._firstScreen = firstScreen;
            BusyIndicator = new BusyIndicatorViewModel();

        }

        public BusyIndicatorViewModel BusyIndicator { get; set; }


        protected override void OnInitialize()
        {
            ActivateItem(_firstScreen);
            base.OnInitialize();

        }

        public void Back()
        {
            ActivateItem(_firstScreen);
        }

    }


}
