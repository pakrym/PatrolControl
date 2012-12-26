using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PatrolControl.Service.Model;

namespace PatrolControl.Service
{
    
    [ServiceContract]
    public interface IPatrolControlService
    {
        #region Get

        [OperationContract]
        IList<Building> GetBuildings();

        [OperationContract]
        IList<Street> GetStreets();

        [OperationContract]
        IList<PatrolDistrict> GetPatrolDistricts();

        [OperationContract]
        IList<TownDistrict> GetTownDistricts();

        [OperationContract]
        IList<Street> GetNearestStreets(DbGeography position, int count);

        [OperationContract]
        IList<Street> GetStreetsWithSimularNames(string name);

        #endregion

        #region Add

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
        void UpdateBuildings(params Building[] buildings);

        [OperationContract]
        void UpdateStreets(params Street[] streets);

        [OperationContract]
        void UpdatePatrolDistricts(params PatrolDistrict[] districts);

        [OperationContract]
        void UpdateTownDistricts(params TownDistrict[] districts);

        #endregion

        #region Delete

        void DeleteBuildings(params Building[] buildings);

        void DeleteStreets(params Street[] streets);

        void DeletePatrolDistricts(params PatrolDistrict[] districts);

        void DeleteTownDistricts(params TownDistrict[] districts);

        #endregion
    }
   
}
