using System;
using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    [GenerateProvider]
    public class PatrolDistrict : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }
}