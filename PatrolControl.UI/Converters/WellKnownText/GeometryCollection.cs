using System.Collections.Generic;
using ESRI.ArcGIS.Client.Geometry;

namespace PatrolControl.UI.Converters.WellKnownText
{
    public class GeometryCollection : List<Geometry>
    {
        public Envelope Extent
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}