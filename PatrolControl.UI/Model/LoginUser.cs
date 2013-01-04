using PatrolControl.UI.Framework;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Services;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Model
{
    public class LoginUser : IQuery<IUserService,User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
