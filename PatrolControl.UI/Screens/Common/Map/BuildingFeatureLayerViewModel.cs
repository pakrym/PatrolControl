using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class BuildingFeatureLayerViewModel : FeatureLayerViewModel
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

        protected override void UpdateFeature(FeatureGraphics feature)
        {
            
        }

        protected override void AddFeature(FeatureGraphics feature)
        {
            
        }

        protected override void DeleteFeature(FeatureGraphics feature)
        {
            
        }
    }
}