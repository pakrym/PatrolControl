using ESRI.ArcGIS.Client.Geometry;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class BuildingFeatureLayerViewModel : FeatureLayerViewModel
    {
        public BuildingFeatureLayerViewModel(
            [Dependency("buildings")]
            IFeatureProvider featureProvider)
            : base("Buildings", featureProvider, typeof(MapPoint))
        {
        }
    }
}