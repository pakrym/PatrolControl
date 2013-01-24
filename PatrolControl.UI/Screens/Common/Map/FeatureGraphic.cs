using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Projection;
using PatrolControl.UI.Converters.WellKnownText;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureGraphic : Graphic
    {
        private static readonly WebMercator Mercator = new WebMercator();

        public FeatureGraphic(Feature feature)
        {
            Feature = feature;

            if (feature.Geography != null)
                this.Geometry = Mercator.FromGeographic(GeometryFromWKT.Parse(feature.Geography.Geography.WellKnownText));
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