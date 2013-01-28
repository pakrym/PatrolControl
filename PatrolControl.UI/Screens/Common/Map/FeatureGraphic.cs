using System;
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
            {
                this.Geometry = Mercator.FromGeographic(GeometryFromWKT.Parse(feature.Geography.Geography.WellKnownText));
            }

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Geometry")
                {
                    if (Geometry != null)
                        try
                        {

                            if (Feature.Geography == null)
                            {
                                Feature.Geography = new DbGeography() { Geography = new DbGeographyWellKnownValue() };
                            }
                            Feature.Geography.Geography.CoordinateSystemId = 4326;
                            Feature.Geography.Geography.WellKnownText = GeometryToWKT.Write(Mercator.ToGeographic(this.Geometry));
                        }
                        catch (Exception)
                        {

                        }
                }
            };
        }

        public Feature Feature { get; private set; }


        public FeatureGraphic()
            : base()
        {
            AttributeValueChanged += (sender, args) =>
                {

                };

        }
    }


}