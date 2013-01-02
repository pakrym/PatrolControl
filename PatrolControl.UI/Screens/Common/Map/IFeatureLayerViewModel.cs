using System.Collections.ObjectModel;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public interface IFeatureLayerViewModel 
    {
        string Name { get; }

        GraphicCollection Features { get; }
        void Update(Envelope envelope);
        void Commit();

        bool IsVisible { get; set; }
    }
}