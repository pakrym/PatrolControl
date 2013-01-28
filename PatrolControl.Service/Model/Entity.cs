using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PatrolControl.Service.Model
{
        
    [DataContract]
    public class Entity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
    }
}