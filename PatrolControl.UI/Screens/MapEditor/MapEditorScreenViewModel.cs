using System;
using System.Collections.Generic;
using System.Windows.Input;
using Caliburn.Micro;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Toolkit;
using Microsoft.Practices.Unity;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.MapEditor
{
    public class MapEditorScreenViewModel : Screen
    {
        public override string DisplayName
        {
            get
            {
                return "Map Editor";
            }
        }

        public MapEditorScreenViewModel()
        {
            ObjectEditor = new ObjectEditorViewModel();
            ObjectEditor.Saved += (sender, args) => Coroutine.BeginExecute(Saved().GetEnumerator()); 
            ObjectEditor.Cancelled += (sender, args) => Coroutine.BeginExecute(Cancelled().GetEnumerator());
            ObjectEditor.Deleted += (sender, args) => Coroutine.BeginExecute(Deleted().GetEnumerator());
            this.ViewAttached += HandleViewAttached;
        }

        private IEnumerable<IResult> Deleted()
        {
                
        }

        private IEnumerable<IResult> Cancelled()
        {
            GraphicEditor.CancelEditEx();
            yield break;
        }

        private IEnumerable<IResult> Saved()
        {
            GraphicEditor.StopEditEx();
            
            var featureGraphics = SelectedGraphics as FeatureGraphics;

            if (featureGraphics != null)
            {
                featureGraphics.FeatureLayer.MarkEdited(featureGraphics);
            }
            yield break;
        }


        [Dependency("buildings")]
        public IFeatureLayerViewModel BuildingsLayer { get; set; }
        [Dependency("streets")]
        public IFeatureLayerViewModel StreetsLayer { get; set; }

        public EditGeometryExtended GraphicEditor { get; set; }

        public Map Map { get; set; }

        public Graphic SelectedGraphics { get; set; }



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

            GraphicEditor = (EditGeometryExtended)view.Resources["GraphicEditor"];
            Map = (Map)view.FindName("MyMap");

            GraphicEditor.Init(Map);

        }

        public void MouseDown(object sender, GraphicMouseButtonEventArgs e)
        {
            if (SelectedGraphics != e.Graphic)
            {
                if (SelectedGraphics != null)
                {
                    SelectedGraphics.UnSelect();
                    GraphicEditor.CancelEditEx();
                    ObjectEditor.Cancel();
                }

                SelectedGraphics = e.Graphic;
                SelectedGraphics.Select();
                
                GraphicEditor.StartEditEx(SelectedGraphics);

                var featureGraphics = e.Graphic as FeatureGraphics;
                if (featureGraphics != null)
                {
                    ObjectEditor.Edit(featureGraphics.Feature);
                }
            }
        }

    }
}