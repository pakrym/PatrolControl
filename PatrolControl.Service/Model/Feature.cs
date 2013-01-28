using System.Data.Spatial;
using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
    [DataContract]
    public class Feature : Entity
    {
        [DataMember]
        public DbGeography Geography { get; set; }
    }
}