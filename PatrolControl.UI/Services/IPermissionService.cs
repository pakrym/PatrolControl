using System;
using System.Collections.Generic;
using Caliburn.Micro;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Services
{
    public interface IPermissionService : IService
    {
        void Handle(GetScreensForUser command, Action<IEnumerable<IScreen>> callback);
    }

   
}