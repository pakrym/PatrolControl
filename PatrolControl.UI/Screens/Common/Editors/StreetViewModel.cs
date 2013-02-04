using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class StreetViewModel : FeatureGraphicEditorViewModel, IEditorViewModel<Street>
    {
        public StreetViewModel(Street model)
            : base(model)
        {
        }
    }
}