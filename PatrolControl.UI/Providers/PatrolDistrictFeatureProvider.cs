using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public class PatrolDistrictFeatureProvider : ProviderBase, IFeatureProvider
    {
        public Task<Entity[]> List()
        {
            return List(null).ContinueWith(t => (Entity[])t.Result);
        }

        public Entity New()
        {
            return new PatrolDistrict();
        }

        public Task Save(Entity[] entities)
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
            Client.UpdateBuildingsAsync(entities.Cast<Building>().ToArray());

            return tcs.Task;
        }

        public Task Add(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {

                Client.AddPatrolDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);

            };

            Client.AddPatrolDistrictsCompleted += callback;
            Client.AddPatrolDistrictsAsync(entities.Cast<PatrolDistrict>().ToArray());

            return tcs.Task;   
        }

        public Task Remove(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {

                Client.DeletePatrolDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);

            };

            Client.DeletePatrolDistrictsCompleted += callback;
            Client.DeletePatrolDistrictsAsync(entities.Cast<PatrolDistrict>().ToArray());

            return tcs.Task;  
        }

        public Task<Feature[]> List(Envelope envelope)
        {
            var tcs = new TaskCompletionSource<Feature[]>();
            EventHandler<GetPatrolDistrictsCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetPatrolDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetPatrolDistrictsCompleted += callback;
            Client.GetPatrolDistrictsAsync();

            return tcs.Task;
        }
    }
}
