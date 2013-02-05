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
            return _newContext.Users.Where(u => u.Name.Equals(name)).AsEnumerable().SingleOrDefault(u => u.ValidatePasword(password));
        }

        public IList<Building> GetBuildingsWithSimularNames(string name)
        {
            return _newContext.Database.SqlQuery<Building>("EXEC BuildingsWithSimularNames @name", new SqlParameter("name", "%" + name.Trim().Replace(' ', '%') + "%")).ToList();
        }

        /*
        #region Get By Id

        public User GetUser(int id)
        {
            return _newContext.Users.SingleOrDefault(e => e.Id == id);
        }

        public Building GetBuilding(int id)
        {
            return _newContext.Buildings.SingleOrDefault(e => e.Id == id);
        }

        public Street GetStreet(int id)
        {
            return _newContext.Streets.SingleOrDefault(e => e.Id == id);
        }

        public Officer GetOfficer(int id)
        {
            return _newContext.Officers.SingleOrDefault(e => e.Id == id);
        }

        public PatrolDistrict GetPatrolDistrict(int id)
        {
            return _newContext.PatrolDistricts.SingleOrDefault(e => e.Id == id);
        }

        public TownDistrict GetTownDistrict(int id)
        {
            return _newContext.TownDistricts.SingleOrDefault(e => e.Id == id);
        }

        #endregion

        #region Get List

        public IList<User> GetUsers()
        {
            return _newContext.Users.ToList();
        }

        public IList<Building> GetBuildings()
        {
            //List<Building> buildings = new List<Building>();
            //var lonc = 34.804945;
            //var latc = 50.911487;

            //for (int j = 0; j < 10; j++)
            //{
            //    for (int i = 0; i < 36; i++)
            //    {
            //        var lon = lonc + Math.Cos(2 * Math.PI / 36 * i) * (0.01 + 0.01 * j);
            //        var lat = (latc + Math.Sin(2 * Math.PI / 36 * i) * (0.01 + 0.01 * j) / 2);

            //        var p = DbGeography.PointFromText(
            //            string.Format("POINT({0} {1})",
            //                lon.ToString(CultureInfo.InvariantCulture),
            //                lat.ToString(CultureInfo.InvariantCulture)), SRID);

            //        buildings.Add(new Building() { Geography = p, Id = i, Number = i.ToString() });
            //    }
            //}
            //return buildings;
            return _newContext.Buildings.ToList();
        }

        public IList<Street> GetStreets()
        {
            //List<Street> buildings = new List<Street>();

            //var lonc = 34.804945;
            //var latc = 50.911487;

            //var random = new Random();

            //for (int i = 0; i < 36; i++)
            //{
            //    var lon = lonc + (random.NextDouble() / 10 - random.NextDouble() / 20);
            //    var lat = latc + (random.NextDouble() / 10 - random.NextDouble() / 20);

            //    var lon1 = lon + (random.NextDouble() / 10 - random.NextDouble() / 20);
            //    var lat1 = lat + (random.NextDouble() / 10 - random.NextDouble() / 20);


            //    var p = DbGeography.LineFromText(
            //        string.Format("LINESTRING ({0} {1}, {2} {3})",
            //            lon.ToString(CultureInfo.InvariantCulture),
            //            lat.ToString(CultureInfo.InvariantCulture),
            //            lon1.ToString(CultureInfo.InvariantCulture),
            //            lat1.ToString(CultureInfo.InvariantCulture)

            //            ), SRID);

            //    buildings.Add(new Street() { Geography = p, Id = i, Name = i.ToString() });
            //}

            //return buildings;
            return _newContext.Streets.ToList();
        }

        public IList<Officer> GetOfficers()
        {
            return _newContext.Officers.ToList();
        }

        public IList<PatrolDistrict> GetPatrolDistricts()
        {
            return _newContext.PatrolDistricts.ToList();
        }

        public IList<TownDistrict> GetTownDistricts()
        {
            return _newContext.TownDistricts.ToList();
        }

        public IList<Street> GetNearestStreets(DbGeography position, int count)
        {
            return _newContext.Streets.OrderBy(s => s.Geography.Distance(position)).Take(count).ToList();
        }

        //public IList<Street> GetStreetsWithSimularNames(string name)
        //{
        //    //return _context.Streets.Where(e => e.Name.Contains(name)).ToList();
        //    return _context.Database.SqlQuery<Street>("EXEC StreetsWithSimularnames @name", new SqlParameter("name", name)).ToList();
        //}

        public IList<Building> GetBuildingsWithSimularNames(string name)
        {
            return _newContext.Database.SqlQuery<Building>("EXEC BuildingsWithSimularNames @name", new SqlParameter("name", "%" + name.Trim().Replace(' ', '%') + "%")).ToList();
        }

        #endregion

        #region Add

        public void AddUsers(params User[] users)
        {
            foreach (var user in users)
                _newContext.Users.Add(user);
            _newContext.SaveChanges();
        }

        public void AddBuildings(params Building[] buildings)
        {
            foreach (var building in buildings)
                _newContext.Buildings.Add(building);
            _newContext.SaveChanges();
        }

        public void AddOfficers(params Officer[] officers)
        {
            foreach (var officer in officers)
                _newContext.Officers.Add(officer);
            _newContext.SaveChanges();
        }

        public void AddStreets(params Street[] streets)
        {
            foreach (var street in streets)
                _newContext.Streets.Add(street);
            _newContext.SaveChanges();
        }

        public void AddPatrolDistricts(params PatrolDistrict[] districts)
        {
            foreach (var district in districts)
                _newContext.PatrolDistricts.Add(district);
            _newContext.SaveChanges();
        }

        public void AddTownDistricts(params TownDistrict[] districts)
        {
            foreach (var district in districts)
                _newContext.TownDistricts.Add(district);
            _newContext.SaveChanges();
        }

        #endregion

        #region Update

        public void UpdateUsers(params User[] users)
        {
            foreach (var user in users)
            {
                _newContext.Users.Attach(user);
                _newContext.Entry(user).State = EntityState.Modified;
            }
            _newContext.SaveChanges();
        }

        public void UpdateOfficers(params Officer[] officers)
        {
            foreach (var officer in officers)
            {
                _newContext.Officers.Attach(officer);
                _newContext.Entry(officer).State = EntityState.Modified;
            }
            _newContext.SaveChanges();
        }

        public void UpdateBuildings(params Building[] buildings)
        {
            foreach (var building in buildings)
            {
<<<<<<< HEAD
                _newContext.Buildings.Attach(building);
                _newContext.Entry(building).State = EntityState.Modified;
=======
                _context.Buildings.Attach(building);
                _context.Entry(building).State = EntityState.Modified;

>>>>>>> f26c314258bbd2d43aeef02ee3da677f5e2c1e12
            }
            _newContext.SaveChanges();
        }

        public void UpdateStreets(params Street[] streets)
        {
            var context = _newContext;
            foreach (var street in streets)
            {
                context.Streets.Attach(street);
                context.Entry(street).State = EntityState.Modified;
            }
            context.SaveChanges();

        }

        public void UpdatePatrolDistricts(params PatrolDistrict[] districts)
        {
            foreach (var district in districts)
            {
                _newContext.PatrolDistricts.Attach(district);
                _newContext.Entry(districts).State = EntityState.Modified;
            }
                
            _newContext.SaveChanges();
        }

        public void UpdateTownDistricts(params TownDistrict[] districts)
        {
            foreach (var district in districts)
            {
                _newContext.TownDistricts.Attach(district);
                _newContext.Entry(districts).State = EntityState.Modified;
            }    
            _newContext.SaveChanges();
        }

        #endregion

        #region Delete

        public void DeleteUsers(params User[] users)
        {
            foreach (var user in _newContext.Users.Where(b => users.Any(e => e.Id == b.Id)))
                _newContext.Users.Remove(user);
            _newContext.SaveChanges();
        }

        public void DeleteBuildings(params Building[] buildings)
        {
            foreach (var building in _newContext.Buildings.Where(b => buildings.Any(e => e.Id == b.Id)))
                _newContext.Buildings.Remove(building);
            _newContext.SaveChanges();
        }

        public void DeleteStreets(params Street[] streets)
        {
            foreach (var street in _newContext.Streets.Where(b => streets.Any(e => e.Id == b.Id)))
                _newContext.Streets.Remove(street);
            _newContext.SaveChanges();
        }

        public void DeleteOfficers(params Officer[] officers)
        {
            foreach (var officer in _newContext.Officers.Where(b => officers.Any(e => e.Id == b.Id)))
                _newContext.Officers.Remove(officer);
            _newContext.SaveChanges();
        }

        public void DeletePatrolDistricts(params PatrolDistrict[] districts)
        {
            foreach (var district in _newContext.PatrolDistricts.Where(b => districts.Any(e => e.Id == b.Id)))
                _newContext.PatrolDistricts.Remove(district);
            _newContext.SaveChanges();
        }

        public void DeleteTownDistricts(params TownDistrict[] districts)
        {
            foreach (var district in _newContext.TownDistricts.Where(b => districts.Any(e => e.Id == b.Id)))
                _newContext.TownDistricts.Remove(district);
            _newContext.SaveChanges();
        }

        #endregion
        */
    }
}
