using PatrolControl.UI.Framework;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Services
{
    public class BackendService: ServiceBase
    {
        public BackendService()
        {
            Client = new PatrolControlServiceClient();
        }

        protected PatrolControlServiceClient Client { get; set; }
    }
}