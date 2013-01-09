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
        public DatabaseContext()
            : base("PatrolControl")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<PatrolDistrict> PatrolDistricts { get; set; }
        public DbSet<TownDistrict> TownDistricts { get; set; }

        public class Initializer : IDatabaseInitializer<DatabaseContext>
        {
            public void InitializeDatabase(DatabaseContext context)
            {
                if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
                {
                    context.Database.Delete();
                    (new ModelInstaller()).Install(context, "PatrolControl.Service.Model.Sql");
                }
            }
        }
    }

    [DataContract]
    public class User : Entity
    {
        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String PasswordHash { get; set; }

        
        private String Password 
        {
            set { PasswordHash = Encript(value); }
        }

        [DataMember]
        public int Type { get; set; }

        private static String Encript(String value)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(value);

            var hash = x.ComputeHash(data);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public bool ValidatePasword(String pasword)
        {
            return PasswordHash.Equals(Encript(pasword));
        }
    }

    [DataContract]
    public class Feature : Entity
    {
        [DataMember]
        public DbGeography Geography { get; set; }
    }

    [DataContract]
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

    [DataContract]
    public class Street : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }

    [DataContract]
    public class PatrolDistrict : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }

    [DataContract]
    public class TownDistrict : Feature
    {
        [DataMember]
        public String Name { get; set; }
    }

    [DataContract]
    public class Entity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
    }
}