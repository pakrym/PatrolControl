using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.Converters.WellKnownText;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Services;
using PatrolControl.UI.Utilities;
using Caliburn.Micro;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureLayerViewModel : PropertyChangedBase, IFeatureLayerViewModel
    {
        private readonly IFeatureProvider _featureProvider;
        private bool _isVisible;


        public FeatureLayerViewModel(string name, IFeatureProvider featureProvider)
        {
            Name = name;
            _featureProvider = featureProvider;
            Features = new GraphicCollection();
            IsVisible = true;
        }

        public string Name { get; private set; }

        public GraphicCollection Features { get; private set; }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (value.Equals(_isVisible)) return;
                _isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        public async void Update(Envelope envelope)
        {
            var features = await _featureProvider.List(envelope);
            SetFeatures(features);
        }

        public async void Commit()
        {
            var edited = UpdatedOfType(Features, FeatureState.Edited);

            var added = UpdatedOfType(Features, FeatureState.Added);

            var deleted = UpdatedOfType(Features, FeatureState.Deleted);
                

            await _featureProvider.Add(added);
            await _featureProvider.Save(edited);
            await _featureProvider.Remove(deleted);
        }

        private Feature[] UpdatedOfType(GraphicCollection collection,FeatureState state )
        {
            return collection.OfType<FeatureGraphics>()
                .Where(feature => feature.State == FeatureState.Deleted)
                .Select(UpdateFeature)
                .ToArray();
        }

        private Feature UpdateFeature(FeatureGraphics graphics)
        {
            
            var feature = graphics.Feature;
            feature.Geography.Geography.WellKnownText =
                    GeometryToWKT.Write(graphics.Geometry);

            return feature;

        }

        public void Add(FeatureGraphics feature)
        {
            feature.State = FeatureState.Added;
        }

        public void Remove(FeatureGraphics feature)
        {
            if (feature.State == FeatureState.Added)
                Features.Remove(feature);
            feature.State = FeatureState.Deleted;
        }

        public void MarkEdited(FeatureGraphics feature)
        {
            feature.State = FeatureState.Edited;
        }

        protected void SetFeatures(IEnumerable<Feature> features)
        {
            Features.Clear();
            foreach (var building in features)
            {
                var geom = building.Geography.ConvertToEsriGeometry();
                geom.SpatialReference = new SpatialReference(4326);

                var m = new ESRI.ArcGIS.Client.Projection.WebMercator();
                var gg = m.FromGeographic(geom);

                var feature = new FeatureGraphics()
                {
                    Feature = building,
                    Geometry = gg,
                    FeatureLayer = this
                };

                Features.Add(feature);
            }
        }
    }
}
