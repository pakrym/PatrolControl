using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Caliburn.Micro;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Toolkit;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
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

        public MapEditorScreenViewModel(ObjectEditorViewModel editorViewModel)
        {
            ObjectEditor = editorViewModel;
            ObjectEditor.Saved += (sender, args) => Coroutine.BeginExecute(Saved());
            ObjectEditor.Cancelled += (sender, args) => Coroutine.BeginExecute(Cancelled().GetEnumerator());
            ObjectEditor.Deleted += (sender, args) => Coroutine.BeginExecute(Deleted().GetEnumerator());
            this.ViewAttached += HandleViewAttached;
        }

        private IEnumerable<IResult> Deleted()
        {
            SaveActiveEdit();

            var featureGraphics = SelectedGraphics as FeatureGraphic;
            if (featureGraphics != null)
                SelectedLayer.Remove(featureGraphics);

            yield return new CommitLayer().AsResult();
            yield return Update(SelectedLayer).AsResult();

            CleanUp();
        }

        private IEnumerable<IResult> Cancelled()
        {
            CancelActiveEdit();


            var featureGraphics = SelectedGraphics as FeatureGraphic;
            if (featureGraphics != null)
                SelectedLayer.SaveOrAdd(featureGraphics);

            //            yield return new CommitLayer().AsResult();

            CleanUp();
            yield break;

        }

        private IEnumerator<IResult> Saved()
        {
            SaveActiveEdit();

            var featureGraphics = SelectedGraphics as FeatureGraphic;
            if (featureGraphics != null)
                SelectedLayer.SaveOrAdd(featureGraphics);


            yield return new CommitLayer() { FeatureLayer = SelectedLayer }.AsResult();
            yield return Update(SelectedLayer).AsResult();

            CleanUp(); 
        }


        [Dependency("buildings")]
        public FeatureLayerViewModel BuildingsLayer { get; set; }
        [Dependency("streets")]
        public FeatureLayerViewModel StreetsLayer { get; set; }

        public EditGeometryExtended GraphicEditor { get; set; }

        public Map Map { get; set; }

        public Graphic SelectedGraphics { get; set; }
        public FeatureLayerViewModel SelectedLayer { get; set; }

        public ObjectEditorViewModel ObjectEditor { get; private set; }

        public FeatureLayerViewModel[] Layers
        {
            get { return new[] { BuildingsLayer, StreetsLayer }; }
        }

        private IEnumerable<IResult> Update(FeatureLayerViewModel layer)
        {
            yield return Show.Busy("Loading " + layer.Name);

            yield return new UpdateLayer() { Layer = layer, Envelope = null }.AsResult();

            yield return Show.NotBusy();
        }

        public IEnumerable<IResult> LoadLayers()
        {
            foreach (var layer in Layers)
            {
                yield return Update(layer).AsResult();
            }
        }


        public void HandleViewAttached(object viewObject, ViewAttachedEventArgs eventArgs)
        {
            var view = (MapEditorScreenView)eventArgs.View;

            GraphicEditor = (EditGeometryExtended)view.Resources["GraphicEditor"];
            Map = (Map)view.FindName("MyMap");

            GraphicEditor.Init(Map);
        }

        public void MouseDown(FeatureLayerViewModel sender, GraphicMouseButtonEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            if (SelectedGraphics != e.Graphic)
            {
                CancelActiveEdit();

                SelectedLayer = sender;
                SelectedGraphics = e.Graphic;
                SelectedGraphics.Select();

                GraphicEditor.StartEditEx(SelectedGraphics);

                var featureGraphics = e.Graphic as FeatureGraphic;
                if (featureGraphics != null)
                {
                    ObjectEditor.Edit(featureGraphics.Feature);
                }
            }
        }

        public void AddStreet()
        {
            Add(StreetsLayer);
        }

        public void AddBuilding()
        {
            Add(BuildingsLayer);
        }

        public void Add(FeatureLayerViewModel featureLayer)
        {
            var model = featureLayer as FeatureLayerViewModel;

            if (model != null)
            {
                var view = model.GetView();
                var layer = view as GraphicsLayer;

                if (layer != null)
                {
                    CancelActiveEdit();

                    var featureGraphics = model.NewFeature();

                    ObjectEditor.Edit(featureGraphics.Feature);
                    GraphicEditor.Add(layer, featureGraphics);
                    SelectedGraphics = featureGraphics;
                    SelectedLayer = model;
                }
            }
        }

        private void SaveActiveEdit()
        {
            if (SelectedGraphics != null)
            {
                SelectedGraphics.UnSelect();
                GraphicEditor.StopEditEx();
                ObjectEditor.Save();
            }
        }

        private void CancelActiveEdit()
        {
            if (SelectedGraphics != null)
            {
                SelectedGraphics.UnSelect();
                GraphicEditor.CancelEditEx();
                ObjectEditor.Cancel();
            }
        }

        private void CleanUp()
        {
            SelectedGraphics = null;
            SelectedLayer = null;
        }
    }
}