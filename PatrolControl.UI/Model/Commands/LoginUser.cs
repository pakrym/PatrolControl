using PatrolControl.UI.Framework;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class LoginUser : IQuery<IUserService,User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
