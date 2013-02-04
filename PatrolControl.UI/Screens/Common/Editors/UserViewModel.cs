using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Caliburn.Micro;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class UserViewModel : ViewModelBase, IEditableObject, IEditorViewModel<User>
    {
        private readonly User _model;
        private string _name;
        private int _type;

        public UserViewModel(User model, IRightProvider rightProvider)
            : base(model)
        {
            UserRights = rightProvider.GetAllRights().Select(r => new UserRightViewModel(this, r)).ToArray();
            _model = model;

            model.PropertyChanged += (sender, args) =>
            {
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => Type);
            };
        }


        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public int Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        public UserRightViewModel[] UserRights { get; set; }

        public void BeginEdit()
        {
            Name = _model.Name;
            Type = _model.Type;
        }

        public void EndEdit()
        {
            _model.Name = Name;
            _model.Type = Type;
        }

        public void CancelEdit()
        {
            BeginEdit();
        }
    }
}
