using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.Converters.WellKnownText;
using PatrolControl.UI.Model;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Services;
using PatrolControl.UI.Utilities;
using Caliburn.Micro;
using Geometry = ESRI.ArcGIS.Client.Geometry.Geometry;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureLayerViewModel : ViewAware
    {

        private readonly Type _geometryType;
        private readonly Type _featureType;
        private bool _isVisible;

        private FeatureCollection _entityCollection;


        public FeatureLayerViewModel(string name, IFeatureProvider featureProvider, Type geometryType)
        {
            _entityCollection = new FeatureCollection(featureProvider);

            Name = name;
            _geometryType = geometryType;
            Features = new FeatureGraphicCollection(_entityCollection.Entities);
            IsVisible = true;
        }

        public string Name { get; private set; }

        public FeatureGraphicCollection Features { get; private set; }

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

        public async Task Update(Envelope envelope)
        {
            await _entityCollection.Update();
        }

        public FeatureGraphic NewFeature()
        {
            return new FeatureGraphic((Feature)_entityCollection.New())
            {
                Geometry = (Geometry)Activator.CreateInstance(_geometryType)
            };
        }

        public Task Commit()
        {
            return _entityCollection.Commit();
        }

        public void Remove(FeatureGraphic featureGraphic)
        { 
            _entityCollection.Delete(featureGraphic.Feature);
        }

        public void SaveOrAdd(FeatureGraphic featureGraphic)
        {
            _entityCollection.SaveOrAdd(featureGraphic.Feature);
        }
    }
}
