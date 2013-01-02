using ESRI.ArcGIS.Client;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureGraphics<T> : Graphic
    {
        public T Feature { get; set; }

        public FeatureState State { get; set; }
    }

    public enum FeatureState
    {
        NotChanged,
        Edited,//???
        Added,
        Deleted
    }
}