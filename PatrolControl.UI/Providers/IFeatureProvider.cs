using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public interface IFeatureProvider
    {
        Task<Feature[]> List(Envelope envelope);
        Task Save(Feature[] feature);
        Task Add(Feature[] feature);
        Task Remove(Feature[] feature);
    }
}