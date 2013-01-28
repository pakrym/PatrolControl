using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Web;

namespace PatrolControl.Service.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("PatrolControl") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<PatrolDistrict> PatrolDistricts { get; set; }
        public DbSet<TownDistrict> TownDistricts { get; set; }

    }

}