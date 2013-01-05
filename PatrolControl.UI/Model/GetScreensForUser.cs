using System.Collections.Generic;
using Caliburn.Micro;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model
{
    public class GetScreensForUser : IQuery<IPermissionService, IEnumerable<IScreen>>
    {
        public int Permissions { get; set; }
    }
}