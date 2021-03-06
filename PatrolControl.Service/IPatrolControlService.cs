﻿using System;
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
    public partial interface IPatrolControlService
    {
        /*
        [OperationContract]
        User Login(String name, String password);

        #region Get By Id

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        Building GetBuilding(int id);

        [OperationContract]
        Street GetStreet(int id);

        [OperationContract]
        Officer GetOfficer(int id);

        [OperationContract]
        PatrolDistrict GetPatrolDistrict(int id);

        [OperationContract]
        TownDistrict GetTownDistrict(int id);

        #endregion

        #region Get List

        [OperationContract]
        IList<User> GetUsers();

        [OperationContract]
        IList<Building> GetBuildings();

        [OperationContract]
        IList<Street> GetStreets();

        [OperationContract]
        IList<Officer> GetOfficers();

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
        void AddOfficers(params Officer[] users);

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
        void UpdateOfficers(params Officer[] users);

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
        void DeleteOfficers(params Officer[] officers);

        [OperationContract]
        void DeletePatrolDistricts(params PatrolDistrict[] districts);

        [OperationContract]
        void DeleteTownDistricts(params TownDistrict[] districts);

        #endregion
        */
    }
   
}
