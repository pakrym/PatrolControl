using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PatrolControl.Service.Model;
using System.Globalization;
using System.Data.SqlClient;

namespace PatrolControl.Service
{
    public partial class PatrolControlService
    {
        public User Login(String name, String password)
        {
            using (var context = getNewContext())
            {
                return
                    context.Users.Where(u => u.Name.Equals(name))
                           .AsEnumerable()
                           .SingleOrDefault(u => u.ValidatePasword(password));
            }
        }

        public IList<Building> GetBuildingsWithSimularNames(string name)
        {
            using (var context = getNewContext())
            {
                return context.Database.SqlQuery<Building>("EXEC BuildingsWithSimularNames @name", new SqlParameter("name", "%" + name.Trim().Replace(' ', '%') + "%")).ToList();
            }
        }
    }
}
