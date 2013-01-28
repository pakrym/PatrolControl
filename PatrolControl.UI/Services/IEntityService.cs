using System.Threading.Tasks;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;

namespace PatrolControl.UI.Services
{
    public interface IEntityService : IService
    {
        Task Handle(UpdateEntities command);
        Task Handle(CommitEntities command);
    }
}