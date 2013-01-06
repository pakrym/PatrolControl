using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model
{
    public class SaveFeature : ICommand<IFeatureService>
    {
        public FeatureGraphics Feature { get; set; }
    }
}