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
    }
   
}
