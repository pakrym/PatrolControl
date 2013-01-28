using PatrolControl.UI.Framework;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class SetBusy: ICommand<IShellService>
    {
        public bool Status { get; set; }
        public string Text { get; set; }
    }

    
}
