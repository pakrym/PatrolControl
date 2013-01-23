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
using Caliburn.Micro;
using ESRI.ArcGIS.Client;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.MapEditor
{
    public partial class MapEditorScreenView : UserControl
    {
        public MapEditorScreenView()
        {
            InitializeComponent();

             
        }

        
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
        private void MouseDown(object sender, GraphicMouseButtonEventArgs e)
        {
            var mapEditorScreenViewModel = DataContext as MapEditorScreenViewModel;

            var vm = ViewModelHelper.GetViewModel(sender as DependencyObject);

            if (mapEditorScreenViewModel != null)
                mapEditorScreenViewModel.MouseDown(vm as FeatureLayerViewModel, e);
        }
    }
}
