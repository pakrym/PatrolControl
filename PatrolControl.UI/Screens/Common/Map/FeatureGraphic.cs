using System;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Projection;
using PatrolControl.UI.Converters.WellKnownText;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureViewModel : ViewModelBase
    {
        private DbGeography _geography;
        public FeatureGraphic Graphic { get; set; }

        public FeatureViewModel(Entity model)
            : base(model)
        {
            FeatureModel = (Feature) model;
            Graphic = new FeatureGraphic(FeatureModel);
        }

        protected Feature FeatureModel { get; set; }

        public DbGeography Geography
        {
            get { return _geography; }
            set
            {
                if (Equals(value, _geography)) return;
                _geography = value;
                NotifyOfPropertyChange(() => Geography);
            }
        }
    }

    public class FeatureGraphic : Graphic
    {
        private static readonly WebMercator Mercator = new WebMercator();

        public FeatureGraphic(Feature feature)
        {
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