using System;
using System.Collections.Generic;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Services
{
    public interface IUserService: IService
    {
        void Handle(LoginUser command, Action<User> callback);
        void Handle(GetLoginUsers command, Action<IEnumerable<User>> callback);

    }
}
