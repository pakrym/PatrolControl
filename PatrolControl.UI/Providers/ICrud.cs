using System.Threading.Tasks;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{

    public interface ICrud<T> where T: Entity
    {
        Task<T[]> List();
        Task<T> Get(int id);

        T New();
        Task Save(T[] entities);
        Task Add(T[] entities);
        Task Remove(T [] entities);
    }

    public interface ICrud
    {
        Task<Entity[]> List();

        Entity New();
        Task Save(Entity[] entities);
        Task Add(Entity[] entities);
        Task Remove(Entity[] entities);
    }
}