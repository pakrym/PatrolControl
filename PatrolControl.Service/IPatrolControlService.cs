using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PatrolControl.Service.Model;

namespace PatrolControl.Service
{
    
    [ServiceContract]
    public interface IPatrolControlService
    {
        [OperationContract]
        User Login(String name, String password);

        #region Get

        [OperationContract]
        IList<User> GetUsers();

        [OperationContract]
        IList<Building> GetBuildings();

        [OperationContract]
        IList<Street> GetStreets();

        [OperationContract]
        IList<PatrolDistrict> GetPatrolDistricts();

        [OperationContract]
        IList<TownDistrict> GetTownDistricts();

        [OperationContract]
        IList<Building> GetBuildingsWithSimularNames(string name);

        #endregion

        #region Add

        [OperationContract]
        void AddUsers(params User[] users);

        [OperationContract]
        void AddBuildings(params Building[] buildings);

        [OperationContract]
        void AddStreets(params Street[] streets);

        [OperationContract]
        void AddPatrolDistricts(params PatrolDistrict[] districts);

        [OperationContract]
        void AddTownDistricts(params TownDistrict[] districts);

        #endregion

        #region Update

        [OperationContract]
        void UpdateUsers(params User[] users);

        [OperationContract]
        void UpdateBuildings(params Building[] buildings);

        [OperationContract]
        void UpdateStreets(params Street[] streets);

        [OperationContract]
        void UpdatePatrolDistricts(params PatrolDistrict[] districts);

        [OperationContract]
        void UpdateTownDistricts(params TownDistrict[] districts);

        #endregion

        #region Delete

        [OperationContract]
        void DeleteUsers(params User[] users);

        [OperationContract]
        void DeleteBuildings(params Building[] buildings);

        [OperationContract]
        void DeleteStreets(params Street[] streets);

        [OperationContract]
        void DeletePatrolDistricts(params PatrolDistrict[] districts);

        [OperationContract]
        void DeleteTownDistricts(params TownDistrict[] districts);

        #endregion
    }
   
}
