using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Services
{
    public interface IShellService: IService
    {
        void Handle(SetBusy command);
    }
}