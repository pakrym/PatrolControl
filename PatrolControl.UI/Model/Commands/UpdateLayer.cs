using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class UpdateLayer : ICommand<IFeatureService>
    {
        public FeatureLayerViewModel Layer { get; set; }
        public Envelope Envelope { get; set; }
    }
}