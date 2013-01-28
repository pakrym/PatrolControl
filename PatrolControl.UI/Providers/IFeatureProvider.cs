using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
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

    public interface IFeatureProvider: ICrud
    {
        Task<Feature[]> List(Envelope envelope);
    }
}