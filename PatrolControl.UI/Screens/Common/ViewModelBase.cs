using Caliburn.Micro;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common
{
    public class ViewModelBase : PropertyChangedBase
    {
        public ViewModelBase(Entity model)
        {
            Model = model;
        }

        public Entity Model { get; private set; }
    }
}