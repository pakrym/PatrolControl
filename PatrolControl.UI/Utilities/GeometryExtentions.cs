using System.Net;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PatrolControl.UI.PatrolControlServiceReference;
using Geometry = ESRI.ArcGIS.Client.Geometry.Geometry;

namespace PatrolControl.UI.Utilities
{
    public static class GeometryExtentions
    {
        public static Geometry ConvertToEsriGeometry(this DbGeography geography)
        {
            return Converters.WellKnownText.GeometryFromWKT.Parse(geography.Geography.WellKnownText);
        }
    }
}