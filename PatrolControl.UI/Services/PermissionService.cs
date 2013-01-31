﻿using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;

namespace PatrolControl.UI.Services
{
    public class PermissionService : ServiceBase, IPermissionService
    {
        private readonly UnityContainer _container;
        private Dictionary<int, string> _screens;

        public PermissionService(UnityContainer container)
        {
            _container = container;
            _screens = new Dictionary<int, string>() {
                {0, "mapeditor"},
                {1, "usermanager"},
                {2, "operationscreen"},
                {3, "officermanager"}
            };
        }

        public void Handle(GetScreensForUser command, Action<IEnumerable<IScreen>> callback)
        {
            var screens = new List<IScreen>();
            for (int i = 0; i < 32; i++)
            {
                if ((1 << i & command.Permissions) > 0)
                {
                    string screenName;
                    if(_screens.TryGetValue(i, out screenName)) 
                        screens.Add(_container.Resolve<IScreen>(screenName));
                }
            }
            callback(screens);
        }
    }
}