using System;
using System.Collections.Generic;
using Caliburn.Micro;
using PatrolControl.UI.Model;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Services
{
    public class UserService : BackendService, IUserService
    {
        public void Handle(LoginUser command, Action<User> callback)
        {
            Client.LoginCompleted += (sender, args) => callback(args.Result);
            Client.LoginAsync(command.Login, command.Password);

        }

        public void Handle(GetLoginUsers command, Action<IEnumerable<User>> callback)
        {
            Client.GetUsersCompleted += (sender, args) => callback(args.Result);
            Client.GetUsersAsync();
        }
    }
}