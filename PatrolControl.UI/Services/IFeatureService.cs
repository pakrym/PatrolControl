using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Services
{
    public interface IFeatureService : IService
    {
        void Handle(SaveFeature command);
        void Handle(UpdateLayer command);
    }

    class FeatureService : ServiceBase, IFeatureService
    {
        public void Handle(SaveFeature command)
        {
            command.Feature.FeatureLayer.MarkEdited(command.Feature);

            command.Feature.FeatureLayer.Commit();
        }

        public void Handle(UpdateLayer command)
        {
            command.Layer.Update(command.Envelope);
        }
    }
}