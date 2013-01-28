using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;

namespace PatrolControl.UI.Services
{
    public interface IShellService: IService
    {
        void Handle(SetBusy command);
    }
}