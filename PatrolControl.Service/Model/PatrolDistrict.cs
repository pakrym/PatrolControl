﻿using System;
using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    public class Officer : Feature
    {
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
    }


    [DataContract]
    public class PatrolDistrict : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }
}