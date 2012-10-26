using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Spatial;
using System.Linq;
using System.Web;

namespace PatrolControl.Service.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Street> Streets { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }

    public class Building
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }

        public int StreetId { get; set; }
        public Street Street { get; set; }

        public long Tags { get; set; }

        public DbGeography Geography { get; set; }
    }

    public class Street
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public DbGeography Geography { get; set; }

    }
}