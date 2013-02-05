using System;
using System.Collections.ObjectModel;
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
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.Converters.WellKnownText;
using PatrolControl.UI.Model;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.MapEditor;
using PatrolControl.UI.Services;
using PatrolControl.UI.Utilities;
using Caliburn.Micro;
using Geometry = ESRI.ArcGIS.Client.Geometry.Geometry;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureLayerViewModel<T, TM> : ViewAware, IFeatureLayerViewModel
        where T : Feature
        where TM : FeatureViewModel
    {
        private readonly Type _geometryType;

        private readonly FeatureCollection<T> _entityCollection;
        private bool _isVisible;

        public FeatureLayerViewModel(string name,
            IFeatureProvider<T> featureProvider,
            Type geometryType,
            Func<T, TM> creator)
        {
            _entityCollection = new FeatureCollection<T>(featureProvider, creator);

            Name = name;
            _geometryType = geometryType;
            IsVisible = true;
            Features = new GraphicCollection();

            _entityCollection.Entities.CollectionChanged += (sender, args) =>
                {
                    Features.Clear();
                    foreach (var entity in _entityCollection.Entities)
                    {
                        Features.Add(entity.Graphic);
                    }
                };
        }


        public GraphicCollection Features { get; private set; }
        public string Name { get; private set; }

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

        public FeatureViewModel NewFeature()
        {
            var vm = _entityCollection.New();
            vm.Graphic.Geometry = (Geometry)Activator.CreateInstance(_geometryType);
            return vm;
        }

        public Task Commit()
        {
            return _entityCollection.Commit();
        }

        public void Remove(FeatureViewModel viewModel)
        {
            _entityCollection.Delete(viewModel);
        }

        public void SaveOrAdd(FeatureViewModel viewModel)
        {
            _entityCollection.SaveOrAdd(viewModel);
        }
    }
}
