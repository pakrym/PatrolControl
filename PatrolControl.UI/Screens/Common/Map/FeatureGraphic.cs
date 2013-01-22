using ESRI.ArcGIS.Client;
using PatrolControl.UI.Converters.WellKnownText;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureGraphic : Graphic
    {
        public FeatureGraphic(Feature feature)
        {
            Feature = feature;
            this.Geometry = GeometryFromWKT.Parse(feature.Geography.Geography.WellKnownText);
        }

        public Feature Feature { get; private set; }

        public FeatureGraphic()
        {
            PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "Geometry")
                    {
                        if (Geometry != null)
                            Feature.Geography.Geography.WellKnownText = GeometryToWKT.Write(this.Geometry);
                    }
                };
        }
    }

    
}