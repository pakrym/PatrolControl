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
    public abstract class FeatureLayerViewModel<T> : PropertyChangedBase, IFeatureLayerViewModel where T : Feature
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
            
        }
        
        public void Add(FeatureGraphics<T> feature)
        {
            feature.State = FeatureState.Added;
        }

        public void Remove(FeatureGraphics<T> feature)
        {
            if (feature.State == FeatureState.Added)
                Features.Remove(feature);
            feature.State = FeatureState.Deleted;
        }

        public void MarkEdited(FeatureGraphics<T> feature)
        {
            feature.State = FeatureState.Edited;
        }

        protected void SetFeatures(IEnumerable<T> features)
        {
            Features.Clear();
            foreach (var building in features)
            {
                var geom = building.Geography.ConvertToEsriGeometry();
                geom.SpatialReference = new SpatialReference(4326);

                var m = new ESRI.ArcGIS.Client.Projection.WebMercator();
                var gg = m.FromGeographic(geom);
                
                var feature = new FeatureGraphics<T>()
                {
                    Feature = building,
                    Geometry = gg
                };

                Features.Add(feature);
            }
        }
    }
}
