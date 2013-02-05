﻿// This file generated automatically, to make changes use partial classes or change T4 template
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PatrolControl.UI.PatrolControlServiceReference;
using ESRI.ArcGIS.Client.Geometry;

namespace PatrolControl.UI.Providers
{

	public partial class BuildingFeatureProvider : ProviderBase, IFeatureProvider 
	{
		public Task<Entity[]> List()
        {
            var tcs = new TaskCompletionSource<Entity[]>();
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

		public Task<Entity> Get(int id)
        {
            var tcs = new TaskCompletionSource<Entity>();
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

	    public Entity New()
        {
            return new Building();
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

                Client.AddUsersCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);

            };

            Client.AddBuildingsCompleted += callback;
            Client.AddBuildingsAsync(entities.Cast<Building>().ToArray());

            return tcs.Task;   
        }

		public Task Remove(Entity[] entities)
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
            Client.DeleteBuildingsAsync(entities.Cast<Building>().ToArray());

            return tcs.Task;   
        }

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
	}

	public partial class OfficerProvider : ProviderBase, ICrud 
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

		public Task<Entity> Get(int id)
        {
            var tcs = new TaskCompletionSource<Entity>();
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

                Client.AddUsersCompleted -= callback;

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

	public partial class PatrolDistrictFeatureProvider : ProviderBase, IFeatureProvider 
	{
		public Task<Entity[]> List()
        {
            var tcs = new TaskCompletionSource<Entity[]>();
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

		public Task<Entity> Get(int id)
        {
            var tcs = new TaskCompletionSource<Entity>();
            EventHandler<GetPatrolDistrictCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetPatrolDistrictCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetPatrolDistrictCompleted += callback;
            Client.GetPatrolDistrictAsync(id);

            return tcs.Task;
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
                Client.UpdatePatrolDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);
            };

            Client.UpdatePatrolDistrictsCompleted += callback;
            Client.UpdatePatrolDistrictsAsync(entities.Cast<PatrolDistrict>().ToArray());

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

	public partial class StreetFeatureProvider : ProviderBase, IFeatureProvider 
	{
		public Task<Entity[]> List()
        {
            var tcs = new TaskCompletionSource<Entity[]>();
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

		public Task<Entity> Get(int id)
        {
            var tcs = new TaskCompletionSource<Entity>();
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

	    public Entity New()
        {
            return new Street();
        }

		public Task Save(Entity[] entities)
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
            Client.UpdateStreetsAsync(entities.Cast<Street>().ToArray());

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

            Client.AddStreetsCompleted += callback;
            Client.AddStreetsAsync(entities.Cast<Street>().ToArray());

            return tcs.Task;   
        }

		public Task Remove(Entity[] entities)
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
            Client.DeleteStreetsAsync(entities.Cast<Street>().ToArray());

            return tcs.Task;   
        }

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
	}

	public partial class TownDistrictFeatureProvider : ProviderBase, IFeatureProvider 
	{
		public Task<Entity[]> List()
        {
            var tcs = new TaskCompletionSource<Entity[]>();
            EventHandler<GetTownDistrictsCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetTownDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetTownDistrictsCompleted += callback;
            Client.GetTownDistrictsAsync();

            return tcs.Task;
        }

		public Task<Entity> Get(int id)
        {
            var tcs = new TaskCompletionSource<Entity>();
            EventHandler<GetTownDistrictCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetTownDistrictCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetTownDistrictCompleted += callback;
            Client.GetTownDistrictAsync(id);

            return tcs.Task;
        }

	    public Entity New()
        {
            return new TownDistrict();
        }

		public Task Save(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.UpdateTownDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);
            };

            Client.UpdateTownDistrictsCompleted += callback;
            Client.UpdateTownDistrictsAsync(entities.Cast<TownDistrict>().ToArray());

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

            Client.AddTownDistrictsCompleted += callback;
            Client.AddTownDistrictsAsync(entities.Cast<TownDistrict>().ToArray());

            return tcs.Task;   
        }

		public Task Remove(Entity[] entities)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler<AsyncCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {

                Client.DeleteTownDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);

            };

            Client.DeleteTownDistrictsCompleted += callback;
            Client.DeleteTownDistrictsAsync(entities.Cast<TownDistrict>().ToArray());

            return tcs.Task;   
        }

	    public Task<Feature[]> List(Envelope envelope)
        {
            var tcs = new TaskCompletionSource<Feature[]>();
            EventHandler<GetTownDistrictsCompletedEventArgs> callback = null;

            callback = (sender, e) =>
            {
                Client.GetTownDistrictsCompleted -= callback;

                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(e.Result);
            };

            Client.GetTownDistrictsCompleted += callback;
            Client.GetTownDistrictsAsync();

            return tcs.Task;
        }
	}

	public partial class UserProvider : ProviderBase, ICrud 
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

		public Task<Entity> Get(int id)
        {
            var tcs = new TaskCompletionSource<Entity>();
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