using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;

namespace PatrolControl.UI.Utilities
{
    public class EditGeometryExtended : EditGeometry
    {
        private Map _map;

        public bool MovingPoint { get; set; }
        public MapPoint InitialLocation { get; set; }
        public Graphic SelectedGraphics { get; set; }


        public void Init(Map map)
        {
            _map = map;

            map.MouseMove += Move;
            foreach (var layer in map.Layers)
            {
                var graphicsLayer = layer as GraphicsLayer;
                if (graphicsLayer != null)
                {
                    graphicsLayer.MouseLeftButtonDown += LeftDown;
                    graphicsLayer.MouseLeftButtonUp += LeftUp;
                }
            }
        }

        public Task Add(GraphicsLayer layer, Graphic graphic)
        {
            var simpleRenderer = layer.Renderer as SimpleRenderer;
            if (simpleRenderer == null)
            {
                throw new InvalidOperationException("Can not add to a layer with non simple renderer");
            }

            var symbol = simpleRenderer.Symbol;

            TaskCompletionSource<object> completionSource = new TaskCompletionSource<object>();

            Editor editor = new Editor();
            editor.Map = _map;
            editor.LayerIDs = new[] { layer.ID };
            editor.EditCompleted += (sender, args) =>
                {
                    if (!args.Edits.Any()) // it was canceled
                    {
                        //completionSource.SetCanceled();
                        return;
                    }

                    var change = args.Edits.First();
                    graphic.Geometry = change.Graphic.Geometry;

                    layer.Graphics.Remove(change.Graphic);

                    layer.Graphics.Add(graphic);
                    AddingToLayer = layer;
                    StartEditEx(graphic);
                    completionSource.SetResult(null);
                };

            editor.Add.Execute(symbol);
            return completionSource.Task;
        }

        protected GraphicsLayer AddingToLayer { get; set; }


        public void StartEditEx(Graphic graphic)
        {
            if (graphic == null) throw new ArgumentNullException("graphic");

            SelectedGraphics = graphic;

            var point = graphic.Geometry as MapPoint;
            if (point != null)
            {
                InitialLocation = point;
            }
            else
            {
                StartEdit(graphic);
            }
        }

        public void CancelEditEx()
        {
            if (SelectedGraphics == null) return;

            var point = SelectedGraphics.Geometry as MapPoint;
            if (point != null)
            {
                SelectedGraphics.Geometry = InitialLocation;
                InitialLocation = null;
            }
            else
            {
                CancelEdit();
            }

            if (AddingToLayer != null)
            {
                AddingToLayer.Graphics.Remove(SelectedGraphics);
            }
            SelectedGraphics = null;
            AddingToLayer = null;

        }

        public void StopEditEx()
        {
            if (SelectedGraphics == null) return;



            var point = SelectedGraphics.Geometry as MapPoint;
            if (point != null)
            {
                InitialLocation = null;
            }
            else
            {
                StopEdit();
            }

            if (AddingToLayer != null)
            {
                AddingToLayer.Refresh();
            }

            SelectedGraphics = null;

            AddingToLayer = null;

        }

        private void Move(object sender, MouseEventArgs e)
        {
            if (SelectedGraphics == null) return;

            var point = SelectedGraphics.Geometry as MapPoint;
            if (MovingPoint && point != null)
            {
                SelectedGraphics.Geometry = Map.ScreenToMap(e.GetPosition(Map));
            }
        }

        private void LeftUp(object sender, GraphicMouseButtonEventArgs e)
        {
            if (SelectedGraphics == null) return;


            var point = SelectedGraphics.Geometry as MapPoint;
            if (point != null)
            {
                MovingPoint = false;
            }
        }

        private void LeftDown(object sender, GraphicMouseButtonEventArgs e)
        {
            if (SelectedGraphics == null) return;


            var point = SelectedGraphics.Geometry as MapPoint;
            if (point != null)
            {
                MovingPoint = true;
                e.Handled = true;
            }
        }
    }
}