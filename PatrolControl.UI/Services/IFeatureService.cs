using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;

namespace PatrolControl.UI.Services
{
    public interface IFeatureService : IService
    {
        void Handle(CommitLayer command);
        void Handle(UpdateLayer command);
    }
}