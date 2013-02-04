using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Screens.MapEditor;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class CommitLayer : ICommand<IFeatureService>
    {
        public IFeatureLayerViewModel FeatureLayer { get; set; }
    }
}