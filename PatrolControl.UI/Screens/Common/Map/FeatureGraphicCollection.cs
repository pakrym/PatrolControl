using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ESRI.ArcGIS.Client;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureGraphicCollection : GraphicCollection
    {
        private readonly ObservableCollection<Entity> _features;

        public FeatureGraphicCollection(ObservableCollection<Entity> features)
        {
            _features = features;
            _features.CollectionChanged += FeaturesChanged;
        }

        private void FeaturesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //TODO: Optimize me
            this.Clear();
            foreach (Feature feature in _features)
            {
                this.Add(ConvertFeature(feature));
            }
        }

        private FeatureGraphic ConvertFeature(Feature feature)
        {
            return new FeatureGraphic(feature);
        }
    }
}