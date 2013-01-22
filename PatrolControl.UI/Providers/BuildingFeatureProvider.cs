using System;
using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public class BuildingFeatureProvider : ProviderBase, IFeatureProvider
    {
        public Task<Feature[]> List(Envelope envelope)
        {
            var tcs = new TaskCompletionSource<Feature[]>();
            EventHandler<GetBuildingsCompletedEventArgs> callback = null;
            
            callback = (sender, e) =>
                {
                    Client.GetBuildingsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(e.Result);

                };

            Client.GetBuildingsCompleted += callback;
            Client.GetBuildingsAsync();

            return tcs.Task;
        }

        public Task Save(Feature[] feature)
        {
            return null;
        }

        public Task Add(Feature[] feature)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Feature[] feature)
        {
            throw new NotImplementedException();
        }

        public Entity New()
        {
            return new Building();
        }
    }
}