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
            if (command.Login == "1" && command.Password == "1")
            {
                callback(new User()
                    {
                        Id = 1,
                        Name = "2",
                        PasswordHash = "3",
                        Type = 3
                    });
            }

            callback(null);
        }

        public void Handle(GetLoginUsers command, Action<IEnumerable<User>> callback)
        {
            callback(new[]
                {
                    new User() {Name = "1",Type = 1},
                    new User() {Name = "2",Type = 2},
                        new User() {Name = "3",Type = 3}
                });
        }
    }
}