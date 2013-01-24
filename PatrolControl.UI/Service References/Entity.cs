using ESRI.ArcGIS.Client;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.PatrolControlServiceReference
{
    public partial class User
    {
        
    }

    public partial class Entity
    {
        private EntityState _state;

        public Entity()
        {
            State = EntityState.New;
            ;
        }

        internal EntityState State
        {
            get { return _state; }
            set { _state = value; }
        }
    }

}