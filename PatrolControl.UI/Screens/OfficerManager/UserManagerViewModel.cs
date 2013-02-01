using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.ListManager;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Screens.OfficerManager
{
    public class OfficerManagerView : ListManagerView
    {
        
    }
    public class OfficerManagerViewModel : ListManagerViewModel<Officer,OfficerViewModel>
    {
        public OfficerManagerViewModel(ObjectEditorViewModel editor)
            : base(new OfficerProvider(), editor)
        {
        }

        public override string DisplayName
        {
            get
            {
                return "Officer Manager";
            }
        }



    }

    public class OfficerViewModel : ViewModelBase
    {
        public OfficerViewModel(Entity model) : base(model)
        {
        }
    }
}
