using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
using PatrolControl.UI.Providers;

namespace PatrolControl.UI.Services
{
    public class PermissionService : ServiceBase, IPermissionService
    {
        private readonly UnityContainer _container;
        private Dictionary<int, string> _screens;

        public PermissionService(UnityContainer container, IRightProvider right)
        {
            _container = container;
            _screens = right.GetAllRights().ToDictionary(r => r.Id, r => r.Screen);
        }

        public void Handle(GetScreensForUser command, Action<IEnumerable<IScreen>> callback)
        {
            var screens = new List<IScreen>();
            for (int i = 0; i < 32; i++)
            {
                if ((1 << i & command.Permissions) > 0)
                {
                    string screenName;
                    if (_screens.TryGetValue(i, out screenName))
                        screens.Add(_container.Resolve<IScreen>(screenName));
                }
            }
            callback(screens);
        }
    }
}