using PatrolControl.UI.Framework;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class UpdateEntities : ICommand<IEntityService>
    {
        public ViewModelCollection Entities { get; set; }
        
    }
}