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
using PatrolControl.UI.Framework;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model
{
    public class SetBusy: ICommand<IShellService>
    {
        public bool Status { get; set; }
        public string Text { get; set; }
    }

    
}
