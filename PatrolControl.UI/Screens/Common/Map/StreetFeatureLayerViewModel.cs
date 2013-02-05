using System;
using ESRI.ArcGIS.Client.Geometry;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common.Editors;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class StreetsFeatureLayerViewModel : FeatureLayerViewModel<Street,StreetViewModel>
    {
        public StreetsFeatureLayerViewModel(IFeatureProvider<Street> featureProvider, Func<Street, StreetViewModel> creator)
            : base("Streets", featureProvider, typeof(Polyline), creator)
        {
        }
    }
}