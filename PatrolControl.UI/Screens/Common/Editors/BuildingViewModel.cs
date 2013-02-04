using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class BuildingViewModel : EditableAdapter<Building>
    {
        public BuildingViewModel(Building model)
            : base(model)
        {
        }
    }
}