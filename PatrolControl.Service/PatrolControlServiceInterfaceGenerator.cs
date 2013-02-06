using System;
using System.Collections.Generic;
using System.ServiceModel;
using PatrolControl.Service.Model;

namespace PatrolControl.Service
{
	[ServiceContract]
	public partial interface IPatrolControlService
	{
	  
		[OperationContract]
		User Login(String name,String password);
	  
		[OperationContract]
		IList<Building> GetBuildingsWithSimularNames(String name);
	  
		[OperationContract]
		User GetUser(Int32 id);
	  
		[OperationContract]
		Officer GetOfficer(Int32 id);
	  
		[OperationContract]
		Street GetStreet(Int32 id);
	  
		[OperationContract]
		Building GetBuilding(Int32 id);
	  
		[OperationContract]
		PatrolDistrict GetPatrolDistrict(Int32 id);
	  
		[OperationContract]
		TownDistrict GetTownDistrict(Int32 id);
	  
		[OperationContract]
		IList<User> GetUsers();
	  
		[OperationContract]
		IList<Officer> GetOfficers();
	  
		[OperationContract]
		IList<Street> GetStreets();
	  
		[OperationContract]
		IList<Building> GetBuildings();
	  
		[OperationContract]
		IList<PatrolDistrict> GetPatrolDistricts();
	  
		[OperationContract]
		IList<TownDistrict> GetTownDistricts();
	  
		[OperationContract]
		void AddUsers(User[] entities);
	  
		[OperationContract]
		void AddOfficers(Officer[] entities);
	  
		[OperationContract]
		void AddStreets(Street[] entities);
	  
		[OperationContract]
		void AddBuildings(Building[] entities);
	  
		[OperationContract]
		void AddPatrolDistricts(PatrolDistrict[] entities);
	  
		[OperationContract]
		void AddTownDistricts(TownDistrict[] entities);
	  
		[OperationContract]
		void UpdateUsers(User[] entities);
	  
		[OperationContract]
		void UpdateOfficers(Officer[] entities);
	  
		[OperationContract]
		void UpdateStreets(Street[] entities);
	  
		[OperationContract]
		void UpdateBuildings(Building[] entities);
	  
		[OperationContract]
		void UpdatePatrolDistricts(PatrolDistrict[] entities);
	  
		[OperationContract]
		void UpdateTownDistricts(TownDistrict[] entities);
	  
		[OperationContract]
		void DeleteUsers(User[] entities);
	  
		[OperationContract]
		void DeleteOfficers(Officer[] entities);
	  
		[OperationContract]
		void DeleteStreets(Street[] entities);
	  
		[OperationContract]
		void DeleteBuildings(Building[] entities);
	  
		[OperationContract]
		void DeletePatrolDistricts(PatrolDistrict[] entities);
	  
		[OperationContract]
		void DeleteTownDistricts(TownDistrict[] entities);
	  
	}
}