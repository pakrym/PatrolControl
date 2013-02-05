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

        public FeatureGraphic(FeatureViewModel feature)
        {
            ViewModel = feature;

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

                            if (ViewModel.Geography == null)
                            {
                                ViewModel.Geography = new DbGeography() { Geography = new DbGeographyWellKnownValue() };
                            }
                            ViewModel.Geography.Geography.CoordinateSystemId = 4326;
                            ViewModel.Geography.Geography.WellKnownText = GeometryToWKT.Write(Mercator.ToGeographic(this.Geometry));
                        }
                        catch (Exception)
                        {

                        }
                }
            };
        }

        
        public FeatureViewModel ViewModel { get; private set; }


        public FeatureGraphic()
            : base()
        {
            AttributeValueChanged += (sender, args) =>
                {

                };

        }
    }


}