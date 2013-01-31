using System;
using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    [GenerateProvider]
    public class TownDistrict : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }
}