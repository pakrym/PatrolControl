using System.Threading.Tasks;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Services
{
    public interface IEntityService : IService
    {
        Task Handle(UpdateEntities command);
        Task Handle(CommitEntities command);
    }
}