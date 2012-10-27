using System;
using System.Collections.Generic;
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
    }
}
