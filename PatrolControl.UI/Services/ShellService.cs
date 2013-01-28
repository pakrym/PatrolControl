using Microsoft.Practices.Unity;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
using PatrolControl.UI.Screens.Shell;

namespace PatrolControl.UI.Services
{
    public class ShellService : ServiceBase, IShellService
    {
        [Dependency]
        public ShellViewModel Shell { get; set; }

        public void Handle(SetBusy command)
        {
            if (command.Status)
            {
                Shell.BusyIndicator.Push(command.Text);
            }
            else
            {
                Shell.BusyIndicator.Pop();
            }
        }
    }
}