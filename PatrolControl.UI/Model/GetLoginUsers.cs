using System.Collections.Generic;
using PatrolControl.UI.Framework;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model
{
    public class GetLoginUsers: IQuery<IUserService,IEnumerable<User>>
    {
    }
}