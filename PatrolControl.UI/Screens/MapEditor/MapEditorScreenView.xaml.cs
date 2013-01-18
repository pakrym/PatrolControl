using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;

namespace PatrolControl.UI.Screens.MapEditor
{
    public partial class MapEditorScreenView : UserControl
    {
        public MapEditorScreenView()
        {
            InitializeComponent();
        }

        private void MouseDown(object sender, GraphicMouseButtonEventArgs e)
        {
            (DataContext as MapEditorScreenViewModel).MouseDown(sender, e);
        }
    }
}
