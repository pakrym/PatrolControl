using System.ServiceModel.DomainServices.Hosting;

namespace PatrolControl.Web.Model
{
    [EnableClientAccess]
    public class Dsa : System.ServiceModel.DomainServices.EntityFramework.DbDomainService<DatabaseContext>
    {
        
    }
}