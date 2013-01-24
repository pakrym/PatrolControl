using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model
{
    public class CommitEntities : ICommand<IEntityService>
    {
        public EntityCollection Entities { get; set; }
    }
}