using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{

    public class StreetFeatureProvider : ProviderBase, IFeatureProvider
    {
        public Task<Feature[]> List(Envelope envelope)
        {
            var tcs = new TaskCompletionSource<Feature[]>();
            EventHandler<GetStreetsCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {
                    Client.GetStreetsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(e.Result);
                };

            Client.GetStreetsCompleted += callback;
            Client.GetStreetsAsync();

            return tcs.Task;
        }

        public Task<Entity[]> List()
        {
            return List(null).ContinueWith(f => (Entity[])f.Result);
        }

        public Entity New()
        {
            return new Street();
        }

        public Task Save(Entity[] feature)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.UpdateStreetsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.UpdateStreetsCompleted += callback;

            Client.UpdateStreetsAsync(feature.Cast<Street>().ToArray());

            return tcs.Task;
        }

        public Task Add(Entity[] feature)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.AddStreetsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.AddStreetsCompleted += callback;
            Client.AddStreetsAsync(feature.Cast<Street>().ToArray());

            return tcs.Task;
        }

        public Task Remove(Entity[] feature)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.DeleteStreetsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.DeleteStreetsCompleted += callback;
            Client.DeleteStreetsAsync(feature.Cast<Street>().ToArray());

            return tcs.Task;
        }

    }
}