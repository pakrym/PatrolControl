using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Services
{
    public class FeatureService : ServiceBase, IFeatureService
    {
        public void Handle(CommitLayer command)
        {
            command.FeatureLayer.Commit();
        }

        public void Handle(UpdateLayer command)
        {
            command.Layer.Update(command.Envelope);
        }
    }

}