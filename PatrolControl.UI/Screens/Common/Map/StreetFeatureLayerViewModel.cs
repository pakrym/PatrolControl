using ESRI.ArcGIS.Client.Geometry;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class StreetsFeatureLayerViewModel : FeatureLayerViewModel
    {
        public StreetsFeatureLayerViewModel(
            [Dependency("streets")]
            IFeatureProvider featureProvider)
            : base("Streets", featureProvider, typeof(Polyline))
        {
        }
    }
}