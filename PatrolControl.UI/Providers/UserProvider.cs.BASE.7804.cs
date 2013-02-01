using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public class UserProvider : ProviderBase, ICrud 
    {
        public Task<Entity[]> List()
        {
            var tcs = new TaskCompletionSource<Entity[]>();
            EventHandler<GetUsersCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {
                    Client.GetUsersCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(e.Result);
                };

            Client.GetUsersCompleted += callback;
            Client.GetUsersAsync();

            return tcs.Task;
        }

        public Entity New()
        {
            return new User();
        }

        public Task Save(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.UpdateUsersCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.UpdateUsersCompleted += callback;
            Client.UpdateUsersAsync(entities.Cast<User>().ToArray());

            return tcs.Task;
        }

        public Task Add(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.AddUsersCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.AddUsersCompleted += callback;
            Client.AddUsersAsync(entities.Cast<User>().ToArray());

            return tcs.Task;   
        }

        public Task Remove(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
                {

                    Client.DeleteUsersCompleted -= callback;

                    if (e.Error != null) tcs.TrySetException(e.Error);
                    else if (e.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);

                };

            Client.DeleteUsersCompleted += callback;
            Client.DeleteUsersAsync(entities.Cast<User>().ToArray());

            return tcs.Task;   
        }
    }
}