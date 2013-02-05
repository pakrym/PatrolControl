using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using PatrolControl.UI.Screens.Common.Editors;
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

            SelectedLayer.Remove(SelectedFeature);

            yield return new CommitLayer().AsResult();
            yield return Update(SelectedLayer).AsResult();

            CleanUp();
        }

        private IEnumerable<IResult> Cancelled()
        {
            CancelActiveEdit();

            SelectedLayer.SaveOrAdd(SelectedFeature);
            //            yield return new CommitLayer().AsResult();

            CleanUp();
            yield break;

        }

        private IEnumerator<IResult> Saved()
        {
            SaveActiveEdit();


            SelectedLayer.SaveOrAdd(SelectedFeature);


            yield return new CommitLayer() { FeatureLayer = SelectedLayer }.AsResult();
            yield return Update(SelectedLayer).AsResult();

            CleanUp();
        }

        [Dependency]
        public BuildingFeatureLayerViewModel BuildingsLayer { get; set; }
        [Dependency]
        public StreetsFeatureLayerViewModel StreetsLayer { get; set; }


        public EditGeometryExtended GraphicEditor { get; set; }

        public Map Map { get; set; }

        public IFeatureLayerViewModel SelectedLayer { get; set; }

        public ObjectEditorViewModel ObjectEditor { get; private set; }

        public IFeatureLayerViewModel[] Layers
        {
            get { return new IFeatureLayerViewModel[] { BuildingsLayer, StreetsLayer }; }
        }

        private IEnumerable<IResult> Update(IFeatureLayerViewModel layer)
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

        public void MouseDown(IFeatureLayerViewModel sender, GraphicMouseButtonEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            var graphic = e.Graphic as FeatureGraphic;
            if (graphic == null)
            {
                return;
            }
            var vm = graphic.ViewModel;

            if (SelectedFeature != vm)
            {
                CancelActiveEdit();

                SelectedFeature = vm;
                SelectedLayer = sender;
                vm.Graphic.Select();

                GraphicEditor.StartEditEx(SelectedFeature.Graphic);
                ObjectEditor.Edit(SelectedFeature);
            }
        }

        protected FeatureViewModel SelectedFeature { get; set; }

        public void AddStreet()
        {
            Add(StreetsLayer);
        }

        public void AddBuilding()
        {
            Add(BuildingsLayer);
        }

        public void Add(IFeatureLayerViewModel featureLayer)
        {
            var model = featureLayer as IFeatureLayerViewModel;

            if (model != null)
            {
                var view = model.GetView();
                var layer = view as GraphicsLayer;

                if (layer != null)
                {
                    CancelActiveEdit();

                    FeatureViewModel viewModel = model.NewFeature();

                    ObjectEditor.Edit(viewModel);
                    GraphicEditor.Add(layer, viewModel.Graphic);
                    SelectedFeature = viewModel;
                    SelectedLayer = model;
                }
            }
        }

        private void SaveActiveEdit()
        {
            if (SelectedFeature != null)
            {
                SelectedFeature.Graphic.UnSelect();
                GraphicEditor.StopEditEx();
                ObjectEditor.Save();
            }
        }

        private void CancelActiveEdit()
        {
            if (SelectedFeature != null)
            {
                SelectedFeature.Graphic.UnSelect();
                GraphicEditor.CancelEditEx();
                ObjectEditor.Cancel();
            }
        }

        private void CleanUp()
        {
            SelectedFeature = null;
            SelectedLayer = null;
        }
    }

    public interface IFeatureLayerViewModel
    {
        object GetView(object context = null);
        FeatureViewModel NewFeature();
        string Name { get; }

        void Remove(FeatureViewModel selectedFeature);
        void SaveOrAdd(FeatureViewModel selectedFeature);
        Task Commit();
        Task Update(Envelope envelope);
    }
}