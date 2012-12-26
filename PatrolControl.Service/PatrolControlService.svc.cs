using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PatrolControl.Service.Model;

namespace PatrolControl.Service
{
    public class PatrolControlService : IPatrolControlService
    {
        private readonly DatabaseContext _context;

        public PatrolControlService()
        {
            _context = new DatabaseContext();
        }

        #region Get

        public IList<Building> GetBuildings()
        {
            return _context.Buildings.ToList();
        }

        public IList<Street> GetStreets()
        {
            return _context.Streets.ToList();
        }

        public IList<PatrolDistrict> GetPatrolDistricts()
        {
            return _context.PatrolDistricts.ToList();
        }

        public IList<TownDistrict> GetTownDistricts()
        {
            return _context.TownDistricts.ToList();
        }

        public IList<Street> GetNearestStreets(DbGeography position, int count)
        {
            return _context.Streets.OrderBy(s => s.Geography.Distance(position)).Take(count).ToList();
        }

        public IList<Street> GetStreetsWithSimularNames(string name)
        {
            //TODO: make it right!
            return _context.Streets.Where(e => e.Name.Contains(name)).ToList();
        }

        #endregion

        #region Add

        public void AddBuildings(params Building[] buildings)
        {
            foreach (var building in buildings)
                _context.Buildings.Add(building);
            _context.SaveChanges();
        }

        public void AddStreets(params Street[] streets)
        {
            foreach (var street in streets)
                _context.Streets.Add(street);
            _context.SaveChanges();
        }

        public void AddPatrolDistricts(params PatrolDistrict[] districts)
        {
            foreach (var district in districts)
                _context.PatrolDistricts.Add(district);
            _context.SaveChanges();
        }

        public void AddTownDistricts(params TownDistrict[] districts)
        {
            foreach (var district in districts)
                _context.TownDistricts.Add(district);
            _context.SaveChanges();
        }

        #endregion

        #region Update

        public void UpdateBuildings(params Building[] buildings)
        {
            var elements = _context.Buildings
                           .Select(b => new {Building = b, Entity = buildings.LastOrDefault(e => e.Id == b.Id)})
                           .Where(e => e.Entity != null);

            foreach (var element in elements)
            {
                element.Entity.Number = element.Building.Number;
                element.Entity.StreetId = element.Building.StreetId;
                element.Entity.Tags = element.Building.Tags;
                element.Entity.Geography = element.Building.Geography;
            }
            _context.SaveChanges();
        }

        public void UpdateStreets(params Street[] streets)
        {
            var elements = _context.Streets
                           .Select(b => new { Street = b, Entity = streets.LastOrDefault(e => e.Id == b.Id) })
                           .Where(e => e.Entity != null);

            foreach (var element in elements)
            {
                element.Entity.Name = element.Street.Name;
                element.Entity.Geography = element.Street.Geography;
            }
            _context.SaveChanges();
        }

        public void UpdatePatrolDistricts(params PatrolDistrict[] districts)
        {
            var elements = _context.PatrolDistricts
                           .Select(b => new { District = b, Entity = districts.LastOrDefault(e => e.Id == b.Id) })
                           .Where(e => e.Entity != null);

            foreach (var element in elements)
            {
                element.Entity.Name = element.District.Name;
                element.Entity.Geography = element.District.Geography;
            }
            _context.SaveChanges();
        }

        public void UpdateTownDistricts(params TownDistrict[] districts)
        {
            var elements = _context.TownDistricts
                           .Select(b => new { District = b, Entity = districts.LastOrDefault(e => e.Id == b.Id) })
                           .Where(e => e.Entity != null);

            foreach (var element in elements)
            {
                element.Entity.Name = element.District.Name;
                element.Entity.Geography = element.District.Geography;
            }
            _context.SaveChanges();
        }

        #endregion

        #region Delete

        public void DeleteBuildings(params Building[] buildings)
        {
            foreach (var building in _context.Buildings.Where(b => buildings.Any(e => e.Id == b.Id)))
                _context.Buildings.Remove(building);
            _context.SaveChanges();
        }

        public void DeleteStreets(params Street[] streets)
        {
            foreach (var street in _context.Streets.Where(b => streets.Any(e => e.Id == b.Id)))
                _context.Streets.Remove(street);
            _context.SaveChanges();
        }

        public void DeletePatrolDistricts(params PatrolDistrict[] districts)
        {
            foreach (var district in _context.PatrolDistricts.Where(b => districts.Any(e => e.Id == b.Id)))
                _context.PatrolDistricts.Remove(district);
            _context.SaveChanges();
        }

        public void DeleteTownDistricts(params TownDistrict[] districts)
        {
            foreach (var district in _context.TownDistricts.Where(b => districts.Any(e => e.Id == b.Id)))
                _context.TownDistricts.Remove(district);
            _context.SaveChanges();
        }

        #endregion
    }
}
