using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{

    public interface IFeatureProvider<T> : ICrud<T> where T: Feature
    {
        Task<T[]> List(Envelope envelope);
    }

    public interface IFeatureProvider : ICrud
    {
        Task<Feature[]> List(Envelope envelope);
    }
}