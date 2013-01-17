using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model
{
    public class UpdateLayer : ICommand<IFeatureService>
    {
        public IFeatureLayerViewModel Layer { get; set; }
        public Envelope Envelope { get; set; }
    }
}