using System;
using System.Windows.Input;
using Caliburn.Micro;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Toolkit;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Screens.MapEditor
{
    public class MapEditorScreenViewModel : ViewAware
    {
        public MapEditorScreenViewModel(User user)
        {
            User = user;
            ObjectEditor = new ObjectEditorViewModel();
            this.ViewAttached += HandleViewAttached;
        }


        [Dependency("buildings")]
        public IFeatureLayerViewModel BuildingsLayer { get; set; }

        [Dependency("streets")]
        public IFeatureLayerViewModel StreetsLayer { get; set; }

        public User User { get; private set; }
        public EditGeometry GraphicEditor { get; set; }
        public Map Map { get; set; }

        public Graphic SelectedGraphics { get; set; }

        public bool MovingPoint { get; set; }
        public MapPoint InitialLocation { get; set; }


        public ObjectEditorViewModel ObjectEditor { get; private set; }

        public IFeatureLayerViewModel[] Layers
        {
            get { return new[] { BuildingsLayer, StreetsLayer }; }
        }

        public void LoadLayers()
        {
            BuildingsLayer.Update(null);
            StreetsLayer.Update(null);
        }

        public void HandleViewAttached(object viewObject, ViewAttachedEventArgs eventArgs)
        {
            var view = (MapEditorScreenView)eventArgs.View;

            GraphicEditor = (EditGeometry)view.Resources["GraphicEditor"];
            Map = (Map)view.FindName("MyMap");
        }

        public void MouseDown(object sender, GraphicMouseButtonEventArgs e)
        {
            if (SelectedGraphics != e.Graphic)
            {
                if (SelectedGraphics != null)
                {
                    SelectedGraphics.UnSelect();
                    GraphicEditor.CancelEdit();
                    ObjectEditor.Cancel();
                    if (SelectedGraphics.Geometry is MapPoint) // return to initial position
                    {
                        SelectedGraphics.Geometry = InitialLocation;
                    }
                }

                SelectedGraphics = e.Graphic;
                SelectedGraphics.Select();
                if (!(SelectedGraphics.Geometry is MapPoint))
                {
                    GraphicEditor.StartEdit(SelectedGraphics);
                }

                var featureGraphics = e.Graphic as FeatureGraphics;
                if (featureGraphics != null)
                {
                    ObjectEditor.Edit(featureGraphics.Feature);
                }
            }

            var point = SelectedGraphics.Geometry as MapPoint;
            if (SelectedGraphics != null && point != null)
            {
                InitialLocation = point;
                MovingPoint = true;
                e.Handled = true;
            }

        }

        public void MouseUp(object sender, GraphicMouseButtonEventArgs e)
        {
            MovingPoint = false;
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {

            if (!MovingPoint || SelectedGraphics == null) return;


            var point = SelectedGraphics.Geometry as MapPoint;
            if (point != null)
            {
                SelectedGraphics.Geometry = Map.ScreenToMap(e.GetPosition(Map));
            }
        }
    }
}