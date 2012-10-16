
namespace PatrolControl.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using PatrolControl.Service.Model;


    // Implements application logic using the DatabaseContext context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DomainService : DbDomainService<DatabaseContext>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Buildings' query.
        public IQueryable<Building> GetBuildings()
        {
            return this.DbContext.Buildings;
        }

        public void InsertBuilding(Building building)
        {
            DbEntityEntry<Building> entityEntry = this.DbContext.Entry(building);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Buildings.Add(building);
            }
        }

        public void UpdateBuilding(Building currentBuilding)
        {
            this.DbContext.Buildings.AttachAsModified(currentBuilding, this.ChangeSet.GetOriginal(currentBuilding), this.DbContext);
        }

        public void DeleteBuilding(Building building)
        {
            DbEntityEntry<Building> entityEntry = this.DbContext.Entry(building);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Buildings.Attach(building);
                this.DbContext.Buildings.Remove(building);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Streets' query.
        public IQueryable<Street> GetStreets()
        {
            return this.DbContext.Streets;
        }

        public void InsertStreet(Street street)
        {
            DbEntityEntry<Street> entityEntry = this.DbContext.Entry(street);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Streets.Add(street);
            }
        }

        public void UpdateStreet(Street currentStreet)
        {
            this.DbContext.Streets.AttachAsModified(currentStreet, this.ChangeSet.GetOriginal(currentStreet), this.DbContext);
        }

        public void DeleteStreet(Street street)
        {
            DbEntityEntry<Street> entityEntry = this.DbContext.Entry(street);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Streets.Attach(street);
                this.DbContext.Streets.Remove(street);
            }
        }
    }
}


