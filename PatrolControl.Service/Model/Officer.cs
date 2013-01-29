using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    public class Officer : Entity
    {
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
    }
}