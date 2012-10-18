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

namespace PatrolControl.UI
{
    public class GoogleCacheTiledLayer:ESRI.ArcGIS.Client.TiledLayer
    {
        protected override void GetTileSource(int level, int row, int col, Action<ImageSource> onComplete)
        {
            
        }
    }
}
