using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    [GenerateProvider(typeof(IFeatureProvider<Street>))]
    public partial class StreetFeatureProvider 
    {
    }
}