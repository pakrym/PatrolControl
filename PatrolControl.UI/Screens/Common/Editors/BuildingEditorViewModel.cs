using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class BuildingEditorViewModel : EditableAdapter<Building>
    {
        public BuildingEditorViewModel(Building model)
            : base(model)
        {
        }
    }
}