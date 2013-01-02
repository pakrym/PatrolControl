using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Screens.MapEditor
{
    public class MapEditorScreenViewModel: PropertyChangedBase
    {
        [Dependency("buildings")]
        public IFeatureLayerViewModel BuildingsLayer { get; set; }
        [Dependency("streets")]
        public IFeatureLayerViewModel StreetsLayer { get; set; }



        public IFeatureLayerViewModel[] Layers
        {
            get { return new[] { BuildingsLayer, StreetsLayer }; }
        }

        public void LoadLayers()
        {
            BuildingsLayer.Update(null);
            StreetsLayer.Update(null);
        }
    }
}