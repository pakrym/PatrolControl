using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Services
{
    public class FeatureService : ServiceBase, IFeatureService
    {
        public async void Handle(CommitLayer command)
        {
            await command.FeatureLayer.Commit();
        }

        public async void Handle(UpdateLayer command)
        {
            await command.Layer.Update(command.Envelope);
        }
    }
}