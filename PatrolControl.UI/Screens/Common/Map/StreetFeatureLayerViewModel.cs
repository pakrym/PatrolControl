using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class StreetFeatureLayerViewModel : FeatureLayerViewModel
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