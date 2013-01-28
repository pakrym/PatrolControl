using System.Threading.Tasks;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;

namespace PatrolControl.UI.Services
{
    public interface IFeatureService : IService
    {
        Task Handle(CommitLayer command);
        Task Handle(UpdateLayer command);
    }
}