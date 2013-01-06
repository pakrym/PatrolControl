using ESRI.ArcGIS.Client;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureGraphics : Graphic
    {
        public Feature Feature { get; set; }

        public FeatureState State { get; set; }

        public FeatureLayerViewModel FeatureLayer { get; set; }

    }

    public enum FeatureState
    {
        NotChanged,
        Edited,//???
        Added,
        Deleted
    }
}