using System;
using ESRI.ArcGIS.Client.Geometry;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common.Editors;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class BuildingFeatureLayerViewModel : FeatureLayerViewModel<Building,BuildingViewModel >
    {
        public BuildingFeatureLayerViewModel(IFeatureProvider<Building> featureProvider, Func<Building, BuildingViewModel> creator)
            : base("Buildings", featureProvider, typeof(MapPoint), creator)
        {
        }
    }
}