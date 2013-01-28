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
using System.Windows.Navigation;
using ESRI.ArcGIS.Client;

namespace PatrolControl.UI.Screens.Operations
{
    public partial class OperationsView : Page
    {
        public OperationsView()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void MouseDown(object sender, GraphicMouseButtonEventArgs e)
        {
            
        }
    }
}
