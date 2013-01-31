using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    [GenerateProvider]
    public class Building : Feature
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public int StreetId { get; set; }
        
        public Street Street { get; set; }

        [DataMember]
        public long Tags { get; set; }
    }
}