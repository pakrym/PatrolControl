using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Services
{
    public interface IFeatureService : IService
    {
        void Handle(CommitLayer command);
        void Handle(UpdateLayer command);
    }
}