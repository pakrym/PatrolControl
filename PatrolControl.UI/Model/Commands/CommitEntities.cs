using PatrolControl.UI.Framework;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class CommitEntities : ICommand<IEntityService>
    {
        public EntityCollection Entities { get; set; }
    }
}