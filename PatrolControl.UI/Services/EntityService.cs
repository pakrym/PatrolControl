using System.Threading.Tasks;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Services
{
    public class EntityService : ServiceBase, IEntityService
    {
        public async Task Handle(UpdateEntities command)
        {
            await command.Entities.Update();
        }

        public async Task Handle(CommitEntities command)
        {
            await command.Entities.Commit();
        }
    }
}