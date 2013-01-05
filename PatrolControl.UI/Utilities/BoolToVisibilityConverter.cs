using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;

namespace PatrolControl.UI.Utilities
{
    public class EditGeometryExtended : EditGeometry
    {

        public bool MovingPoint { get; set; }
        public MapPoint InitialLocation { get; set; }
        public Graphic SelectedGraphics { get; set; }


        public void Init(Map map)
        {
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

        public void StartEditEx(Graphic graphic)
        {
            if (graphic == null) throw new ArgumentNullException("graphic");

            var point = graphic.Geometry as MapPoint;
            if (point != null)
            {
                SelectedGraphics = graphic;
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
                SelectedGraphics = null;
            }
            else
            {
                CancelEdit();
            }
        }

        public void StopEditEx()
        {
            if (SelectedGraphics == null) return;
            

            var point = SelectedGraphics.Geometry as MapPoint;
            if (point != null)
            {
                InitialLocation = null;
                SelectedGraphics = null;
            }
            else
            {
                CancelEdit();
            }

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
                InitialLocation = point;
                MovingPoint = true;
                e.Handled = true;
            }
        }
    }

    public class BoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public BoolToVisibilityConverter()
        {
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Collapsed;
        }

        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = System.Convert.ToBoolean(value);
            return val ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return TrueValue.Equals(value) ? true : false;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}