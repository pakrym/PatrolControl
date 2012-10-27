using System;
using System.Collections.Generic;
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
    }
   
}
