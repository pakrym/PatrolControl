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
    public class OfficerProvider : ProviderBase, ICrud
    {
        public Task<Entity[]> List()
        {
            var tcs = new TaskCompletionSource<Entity[]>();
            EventHandler<GetOfficersCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetOfficersCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetOfficersCompleted += callback;
            Client.GetOfficersAsync();

            return tcs.Task;
        }

        public Entity New()
        {
            return new Officer();
        }

        public Task Save(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {

                Client.UpdateOfficersCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);

            };

            Client.UpdateOfficersCompleted += callback;
            Client.UpdateOfficersAsync(entities.Cast<Officer>().ToArray());

            return tcs.Task;
        }

        public Task Add(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {

                Client.AddOfficersCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);

            };

            Client.AddOfficersCompleted += callback;
            Client.AddOfficersAsync(entities.Cast<Officer>().ToArray());

            return tcs.Task;   
        }

        public Task Remove(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.DeleteOfficersCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);
            };

            Client.DeleteOfficersCompleted += callback;
            Client.DeleteOfficersAsync(entities.Cast<Officer>().ToArray());

            return tcs.Task;   
        }
    }
}
