using ESRI.ArcGIS.Client.Geometry;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class BuildingFeatureLayerViewModel : FeatureLayerViewModel<Building>
    {
        public BuildingFeatureLayerViewModel(
            [Dependency("buildings")]
            IFeatureProvider<Building> featureProvider)
            : base("Buildings", featureProvider, typeof(MapPoint), building => new FeatureViewModel(building))
        {
        }
    }
}