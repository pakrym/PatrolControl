using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class StreetEditorViewModel : EditableAdapter<Street>
    {
        public StreetEditorViewModel(Street model)
            : base(model)
        {
        }
    }
}