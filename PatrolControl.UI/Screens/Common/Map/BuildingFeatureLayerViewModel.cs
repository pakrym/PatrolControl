using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class BuildingFeatureLayerViewModel : FeatureLayerViewModel<Building>
    {
        public override string Name
        {
            get { return "Buildings"; }
        }

        public override void Update(ESRI.ArcGIS.Client.Geometry.Envelope envelope)
        {
            var client = new PatrolControlServiceClient();
            client.GetBuildingsCompleted += (sender, args) => SetFeatures(args.Result);
            client.GetBuildingsAsync();
        }
    }

    public class StreetFeatureLayerViewModel : FeatureLayerViewModel<Street>
    {
        public override string Name
        {
            get { return "Streets"; }
        }

        public override void Update(ESRI.ArcGIS.Client.Geometry.Envelope envelope)
        {
            var client = new PatrolControlServiceClient();
            client.GetStreetsCompleted += (sender, args) => SetFeatures(args.Result);
            client.GetStreetsAsync();
        }
    }
}