using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public interface IFeatureProvider : ICrud
    {
        Task<Feature[]> List(Envelope envelope);
    }
}