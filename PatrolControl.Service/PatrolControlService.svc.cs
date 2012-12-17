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
        private DatabaseContext _context;

        public PatrolControlService()
        {
            _context = new DatabaseContext();
        }

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

        public void AddBuildings(IList<Building> buildings)
        {

        }
    }
}
