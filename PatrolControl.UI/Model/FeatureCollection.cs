using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.Providers;

namespace PatrolControl.UI.Model
{
    public class FeatureCollection : EntityCollection
    {
        private readonly IFeatureProvider _featureProvider;

        public FeatureCollection(IFeatureProvider featureProvider)
            : base(featureProvider)
        {
            _featureProvider = featureProvider;
        }

        public async Task Update(Envelope envelope)
        {
            var features = await _featureProvider.List(envelope);
            
            OnAfterUpdate(features);
            SetEntities(features);
        }

    }
}