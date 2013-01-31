using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class StreetEditorViewModel : FeatureGraphicEditorViewModel, IEditorViewModel<Street>
    {
        public StreetEditorViewModel(Street model)
            : base(model)
        {
        }
    }
}