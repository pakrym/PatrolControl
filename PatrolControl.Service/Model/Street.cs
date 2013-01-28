using System;
using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    public class Street : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }
}