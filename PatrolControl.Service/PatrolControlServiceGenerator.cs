
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Spatial;
using System.Linq;
using PatrolControl.Service.Model;
using System.Data.SqlClient;

namespace PatrolControl.Service
{
	  public partial class PatrolControlService : IPatrolControlService
	  {
	        private int SRID = 4326;

			private DatabaseContext newContext
			{
				get { return new DatabaseContext();}
			}

			#region Get By Id
	  
			public User GetUser(int id)
			{
				using(var context = newContext)
				{
					return context.Users.SingleOrDefault(e => e.Id == id);
				}
			}
	  
			public Officer GetOfficer(int id)
			{
				using(var context = newContext)
				{
					return context.Officers.SingleOrDefault(e => e.Id == id);
				}
			}
	  
			public Street GetStreet(int id)
			{
				using(var context = newContext)
				{
					return context.Streets.SingleOrDefault(e => e.Id == id);
				}
			}
	  
			public Building GetBuilding(int id)
			{
				using(var context = newContext)
				{
					return context.Buildings.SingleOrDefault(e => e.Id == id);
				}
			}
	  
			public PatrolDistrict GetPatrolDistrict(int id)
			{
				using(var context = newContext)
				{
					return context.PatrolDistricts.SingleOrDefault(e => e.Id == id);
				}
			}
	  
			public TownDistrict GetTownDistrict(int id)
			{
				using(var context = newContext)
				{
					return context.TownDistricts.SingleOrDefault(e => e.Id == id);
				}
			}
	  
			#endregion
			
			#region Get List
	 
			public List<User> GetUsers(int id)
			{
				using(var context = newContext)
				{
					return context.Users.ToList();
				}
			}
	  
			public List<Officer> GetOfficers(int id)
			{
				using(var context = newContext)
				{
					return context.Officers.ToList();
				}
			}
	  
			public List<Street> GetStreets(int id)
			{
				using(var context = newContext)
				{
					return context.Streets.ToList();
				}
			}
	  
			public List<Building> GetBuildings(int id)
			{
				using(var context = newContext)
				{
					return context.Buildings.ToList();
				}
			}
	  
			public List<PatrolDistrict> GetPatrolDistricts(int id)
			{
				using(var context = newContext)
				{
					return context.PatrolDistricts.ToList();
				}
			}
	  
			public List<TownDistrict> GetTownDistricts(int id)
			{
				using(var context = newContext)
				{
					return context.TownDistricts.ToList();
				}
			}
	  			#endregion

			#region Add
	 
			public void AddUsers(params User[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
						context.Users.Add(entity);
					context.SaveChanges();
				}
			}
	  
			public void AddOfficers(params Officer[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
						context.Officers.Add(entity);
					context.SaveChanges();
				}
			}
	  
			public void AddStreets(params Street[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
						context.Streets.Add(entity);
					context.SaveChanges();
				}
			}
	  
			public void AddBuildings(params Building[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
						context.Buildings.Add(entity);
					context.SaveChanges();
				}
			}
	  
			public void AddPatrolDistricts(params PatrolDistrict[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
						context.PatrolDistricts.Add(entity);
					context.SaveChanges();
				}
			}
	  
			public void AddTownDistricts(params TownDistrict[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
						context.TownDistricts.Add(entity);
					context.SaveChanges();
				}
			}
	  			#endregion

			#region Update
	 
			public void UpdateUsers(params User[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
					{
						context.Users.Attach(entity);
						context.Entry(entity).State = EntityState.Modified;
					}
					context.SaveChanges();
				}
			}
	  
			public void UpdateOfficers(params Officer[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
					{
						context.Officers.Attach(entity);
						context.Entry(entity).State = EntityState.Modified;
					}
					context.SaveChanges();
				}
			}
	  
			public void UpdateStreets(params Street[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
					{
						context.Streets.Attach(entity);
						context.Entry(entity).State = EntityState.Modified;
					}
					context.SaveChanges();
				}
			}
	  
			public void UpdateBuildings(params Building[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
					{
						context.Buildings.Attach(entity);
						context.Entry(entity).State = EntityState.Modified;
					}
					context.SaveChanges();
				}
			}
	  
			public void UpdatePatrolDistricts(params PatrolDistrict[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
					{
						context.PatrolDistricts.Attach(entity);
						context.Entry(entity).State = EntityState.Modified;
					}
					context.SaveChanges();
				}
			}
	  
			public void UpdateTownDistricts(params TownDistrict[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in entities)
					{
						context.TownDistricts.Attach(entity);
						context.Entry(entity).State = EntityState.Modified;
					}
					context.SaveChanges();
				}
			}
	  			#endregion

			#region Delete
	 
			public void DeleteUsers(params User[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in context.Users.Where(b => entities.Any(e => e.Id == b.Id)))
						context.Users.Remove(entity);
					context.SaveChanges();
				}
			}
	  
			public void DeleteOfficers(params Officer[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in context.Officers.Where(b => entities.Any(e => e.Id == b.Id)))
						context.Officers.Remove(entity);
					context.SaveChanges();
				}
			}
	  
			public void DeleteStreets(params Street[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in context.Streets.Where(b => entities.Any(e => e.Id == b.Id)))
						context.Streets.Remove(entity);
					context.SaveChanges();
				}
			}
	  
			public void DeleteBuildings(params Building[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in context.Buildings.Where(b => entities.Any(e => e.Id == b.Id)))
						context.Buildings.Remove(entity);
					context.SaveChanges();
				}
			}
	  
			public void DeletePatrolDistricts(params PatrolDistrict[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in context.PatrolDistricts.Where(b => entities.Any(e => e.Id == b.Id)))
						context.PatrolDistricts.Remove(entity);
					context.SaveChanges();
				}
			}
	  
			public void DeleteTownDistricts(params TownDistrict[] entities)
			{
				using(var context = newContext)
				{
					foreach (var entity in context.TownDistricts.Where(b => entities.Any(e => e.Id == b.Id)))
						context.TownDistricts.Remove(entity);
					context.SaveChanges();
				}
			}
	  
			#endregion
	  }
}
