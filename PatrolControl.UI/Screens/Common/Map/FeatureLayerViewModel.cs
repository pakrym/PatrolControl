using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Utilities;
using Caliburn.Micro;

namespace PatrolControl.UI.Screens.Common.Map
{
    public abstract class FeatureLayerViewModel : PropertyChangedBase, IFeatureLayerViewModel
    {
        private bool _isVisible;

        protected FeatureLayerViewModel()
        {
            Features = new GraphicCollection();
            IsVisible = true;
        }

        public abstract string Name { get; }

        public GraphicCollection Features { get; private set; }

        public abstract void Update(Envelope envelope);

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

        public void Commit()
        {
            foreach (FeatureGraphics feature in Features)
            {
                if (feature.State == FeatureState.Edited)
                {
                    UpdateFeature(feature);
                }
                if (feature.State == FeatureState.Added)
                {
                    AddFeature(feature);
                }
                if (feature.State == FeatureState.Deleted)
                {
                    DeleteFeature(feature);
                }
            }
        }

        protected abstract void UpdateFeature(FeatureGraphics feature);
        protected abstract void AddFeature(FeatureGraphics feature);
        protected abstract void DeleteFeature(FeatureGraphics feature);

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
