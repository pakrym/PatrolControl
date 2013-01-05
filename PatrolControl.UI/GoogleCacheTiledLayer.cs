using System;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;

namespace PatrolControl.UI
{

    public class GoogleCacheTiledLayer : TiledMapServiceLayer
    {
        private double cornerCoordinate = 20037508;
        private const int WKID = 102113;

        public GoogleCacheTiledLayer()
        {
              if (Application.Current.Host.Source != null)
              {
                  baseUrl = new Uri(Application.Current.Host.Source, "../TileImage.ashx?z={0}&x={1}&y={2}").                  OriginalString;
                //  baseUrl = "http://a.tile.openstreetmap.org/{0}/{1}/{2}.png";
              }
        }

        private string baseUrl;

        public override void Initialize()
        {
            //Full extent fo the layer
            this.FullExtent = new ESRI.ArcGIS.Client.Geometry.Envelope(-cornerCoordinate, -cornerCoordinate, cornerCoordinate, cornerCoordinate)
            {
                SpatialReference = new SpatialReference(WKID)
            };
            //This layer's spatial reference
            //Set up tile information. Each tile is 256x256px, 19 levels.
            this.TileInfo = new TileInfo()
            {
                Height = 256,
                Width = 256,
                Origin = new MapPoint(-20037508, 20070700.342789244) { SpatialReference = new ESRI.ArcGIS.Client.Geometry.SpatialReference(WKID) },
                Lods = new Lod[18]
            };
            //Set the resolutions for each level. Each level is half the resolution of the previous one.
            double resolution = cornerCoordinate * 2 / 256;
            for (int i = 0; i < TileInfo.Lods.Length; i++)
            {
                TileInfo.Lods[i] = new Lod() { Resolution = resolution };
                resolution /= 2;
            }
            //Call base initialize to raise the initialization event
            base.Initialize(); 
        }

        public override string GetTileUrl(int level, int row, int col)
        {
            // Select a subdomain based on level/row/column so that it will always
            // be the same for a specific tile. Multiple subdomains allows the user
            // to load more tiles simultanously. To take advantage of the browser cache
            // the following expression also makes sure that a specific tile will always 
            // hit the same subdomain.
            
            return string.Format(baseUrl, level, col, row);
        }
    }

    //public class GoogleCacheTiledLayer : ESRI.ArcGIS.Client.TiledLayer
    //{
    //    public GoogleCacheTiledLayer()
    //    {
            
    //        FullExtent =new Envelope(34,50,35,51);
    //    }

    //    protected override void GetTileSource(int level, int row, int col, Action<ImageSource> onComplete)
    //    {
    //        onComplete(new BitmapImage(new Uri(string.Format("/TileImage.ashx?x={0}&y={1}&z={2}", row, col, level))));
    //    }

    //    protected override void Cancel()
    //    {
    //        base.Cancel();
    //    }

    //    protected override void OnMapChanged(Map oldValue, Map newValue)
    //    {
    //        base.OnMapChanged(oldValue, newValue);
    //    }

    //    public override void Initialize()
    //    {
    //        base.Initialize();
    //    }

    //    public override Envelope FullExtent { get; protected set; }

    //    public override string ToString()
    //    {
    //        return base.ToString();
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        return base.Equals(obj);
    //    }
    //}
}
