 
 
 
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using PatrolControl.UI.PatrolControlServiceReference;
using ESRI.ArcGIS.Client.Geometry;

namespace PatrolControl.UI.Providers
{

	public partial class OfficerProvider : ProviderBase, ICrud<Officer>
	{

			public Task<Officer[]> List()
        {
            var tcs = new TaskCompletionSource<Officer[]>();
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

		public Task<Officer> Get(int id)
        {
            var tcs = new TaskCompletionSource<Officer>();
            EventHandler<GetOfficerCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetOfficerCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetOfficerCompleted += callback;
            Client.GetOfficerAsync(id);

            return tcs.Task;
        }

	    public Officer New()
        {
            return new Officer();
        }

		public Task Save(Officer[] entities)
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
            Client.UpdateOfficersAsync(entities.ToArray());

            return tcs.Task;
        }

		public Task Add(Officer[] entities)
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

            Client.AddOfficersCompleted += callback;
            Client.AddOfficersAsync(entities.ToArray());

            return tcs.Task;   
        }

		public Task Remove(Officer[] entities)
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
            Client.DeleteOfficersAsync(entities.ToArray());

            return tcs.Task;   
        }

	}



	public partial class StreetFeatureProvider : ProviderBase, IFeatureProvider<Street>
	{

			public Task<Street[]> List()
        {
            var tcs = new TaskCompletionSource<Street[]>();
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

		public Task<Street> Get(int id)
        {
            var tcs = new TaskCompletionSource<Street>();
            EventHandler<GetStreetCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetStreetCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetStreetCompleted += callback;
            Client.GetStreetAsync(id);

            return tcs.Task;
        }

	    public Street New()
        {
            return new Street();
        }

		public Task Save(Street[] entities)
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
            Client.UpdateStreetsAsync(entities.ToArray());

            return tcs.Task;
        }

		public Task Add(Street[] entities)
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

            Client.AddStreetsCompleted += callback;
            Client.AddStreetsAsync(entities.ToArray());

            return tcs.Task;   
        }

		public Task Remove(Street[] entities)
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
            Client.DeleteStreetsAsync(entities.ToArray());

            return tcs.Task;   
        }

	    public Task<Street[]> List(Envelope envelope)
        {
            var tcs = new TaskCompletionSource<Street[]>();
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
	}



	public partial class UserProvider : ProviderBase, ICrud<User>
	{

			public Task<User[]> List()
        {
            var tcs = new TaskCompletionSource<User[]>();
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

		public Task<User> Get(int id)
        {
            var tcs = new TaskCompletionSource<User>();
            EventHandler<GetUserCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetUserCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetUserCompleted += callback;
            Client.GetUserAsync(id);

            return tcs.Task;
        }

	    public User New()
        {
            return new User();
        }

		public Task Save(User[] entities)
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
            Client.UpdateUsersAsync(entities.ToArray());

            return tcs.Task;
        }

		public Task Add(User[] entities)
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
            Client.AddUsersAsync(entities.ToArray());

            return tcs.Task;   
        }

		public Task Remove(User[] entities)
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
            Client.DeleteUsersAsync(entities.ToArray());

            return tcs.Task;   
        }

	}



	public partial class BuildingFeatureProvider : ProviderBase, IFeatureProvider<Building>
	{

			public Task<Building[]> List()
        {
            var tcs = new TaskCompletionSource<Building[]>();
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

		public Task<Building> Get(int id)
        {
            var tcs = new TaskCompletionSource<Building>();
            EventHandler<GetBuildingCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetBuildingCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetBuildingCompleted += callback;
            Client.GetBuildingAsync(id);

            return tcs.Task;
        }

	    public Building New()
        {
            return new Building();
        }

		public Task Save(Building[] entities)
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
            Client.UpdateBuildingsAsync(entities.ToArray());

            return tcs.Task;
        }

		public Task Add(Building[] entities)
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

            Client.AddBuildingsCompleted += callback;
            Client.AddBuildingsAsync(entities.ToArray());

            return tcs.Task;   
        }

		public Task Remove(Building[] entities)
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
            Client.DeleteBuildingsAsync(entities.ToArray());

            return tcs.Task;   
        }

	    public Task<Building[]> List(Envelope envelope)
        {
            var tcs = new TaskCompletionSource<Building[]>();
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
	}


}

