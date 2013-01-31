using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public class BuildingFeatureProvider : ProviderBase, IFeatureProvider
    {
        public Task<Feature[]> List(Envelope envelope)
        {
            Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttributes(typeof(int), true).Any());
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


        public Task<Entity[]> List()
        {
            return List(null).ContinueWith(t => (Entity[])t.Result);
        }

        public Task Save(Entity[] feature)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {
                    Client.UpdateBuildingsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);
                };

            Client.UpdateBuildingsCompleted += callback;
            Client.UpdateBuildingsAsync(feature.Cast<Building>().ToArray());

            return tcs.Task;
        }

        public Task Add(Entity[] feature)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.AddBuildingsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.AddBuildingsCompleted += callback;
            Client.AddBuildingsAsync(feature.Cast<Building>().ToArray());

            return tcs.Task;   
        }

        public Task Remove(Entity[] feature)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.DeleteBuildingsCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.DeleteBuildingsCompleted += callback;
            Client.DeleteBuildingsAsync(feature.Cast<Building>().ToArray());

            return tcs.Task;   
        }

        public Entity New()
        {
            return new Building();
        }
    }
}