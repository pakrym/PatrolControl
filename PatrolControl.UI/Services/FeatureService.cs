using System.Threading.Tasks;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Services
{
    public class FeatureService : ServiceBase, IFeatureService
    {
        public async Task Handle(CommitLayer command)
        {
            await command.FeatureLayer.Commit();
        }

        public async Task Handle(UpdateLayer command)
        {
            await command.Layer.Update(command.Envelope);
        }
    }
}