using Caliburn.Micro;
using ESRI.ArcGIS.Client;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Screens.MapEditor
{
    public class MapEditorScreenViewModel : PropertyChangedBase
    {
        public MapEditorScreenViewModel()
        {
            ObjectEditor = new ObjectEditorViewModel();
        }

        [Dependency("buildings")]
        public IFeatureLayerViewModel BuildingsLayer { get; set; }
        [Dependency("streets")]
        public IFeatureLayerViewModel StreetsLayer { get; set; }

        public ObjectEditorViewModel ObjectEditor { get; private set; }

        public IFeatureLayerViewModel[] Layers
        {
            get { return new[] { BuildingsLayer, StreetsLayer }; }
        }

        public void Click(object sender, GraphicMouseButtonEventArgs e)
        {
            e.Graphic.Select();
            var featureGraphics = e.Graphic as FeatureGraphics;
            if (featureGraphics != null)
            {
                ObjectEditor.Edit(featureGraphics.Feature);    
            }   
        }

        public void LoadLayers()
        {
            BuildingsLayer.Update(null);
            StreetsLayer.Update(null);
        }
    }
}