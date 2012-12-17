using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PatrolControl.Service.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Street> Streets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<PatrolDistrict> PatrolDistricts { get; set; }
        public DbSet<TownDistrict> TownDistricts { get; set; }
    }

    [DataContract]
    public class Building : Entity
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public int StreetId { get; set; }
        
        public Street Street { get; set; }

        [DataMember]
        public long Tags { get; set; }

        [DataMember]
        public DbGeography Geography { get; set; }
    }

    [DataContract]
    public class Street : Entity
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public DbGeography Geography { get; set; }

    }

    [DataContract]
    public class PatrolDistrict : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DbGeography Geography { get; set; }
    }

    [DataContract]
    public class TownDistrict : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DbGeography Geography { get; set; }
    }

    [DataContract]
    public class Entity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
    }
}