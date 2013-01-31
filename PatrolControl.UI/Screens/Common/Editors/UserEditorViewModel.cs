using System;
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
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class UserEditorViewModel : EditableAdapter<User>
    {
        public UserEditorViewModel(User model) : base(model)
        {
        }
    }
}
