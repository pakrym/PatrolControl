using System.Threading.Tasks;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public interface ICrud
    {
        Task<Entity[]> List();

        Entity New();
        Task Save(Entity[] entities);
        Task Add(Entity[] entities);
        Task Remove(Entity[] entities);
    }
}