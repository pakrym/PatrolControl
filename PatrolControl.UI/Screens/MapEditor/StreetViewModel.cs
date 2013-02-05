using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class StreetViewModel : FeatureViewModel, IEditorViewModel<Street>
    {
        public StreetViewModel(Street model)
            : base(model)
        {
        }
    }
}